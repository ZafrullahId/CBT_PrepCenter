using CBTPreparation.Application.Abstractions.Service;
using CBTPreparation.Domain.FreeQuestionAggregate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Hangfire;
using CBTPreparation.Domain;

namespace CBTPreparation.Infrastructure.BackgroundJobService
{
    public class QuestionBackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<QuestionBackgroundService> _logger;

        public QuestionBackgroundService(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<QuestionBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        [AutomaticRetry(Attempts = 3)]
        public async Task FetchAndProcessQuestions(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running monthly question update job.");

            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var questionRepository = scope.ServiceProvider.GetRequiredService<IFreeQuestionRepository>();
                    var questionsApi = scope.ServiceProvider.GetRequiredService<IGetApiQuestionService>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWorkRepository>();

                   
                    await ProcessSubjects(questionRepository, questionsApi, unitOfWork, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during the monthly question update job: {ex.Message}");
            }
        }

        private async Task ProcessSubjects(
            IFreeQuestionRepository questionRepository,
            IGetApiQuestionService questionsApi,
            IUnitOfWorkRepository unitOfWork, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching and processing subjects.");

            var subjectResponse = await questionsApi.GetAllSubjects();

            if (subjectResponse.Status == 200 && subjectResponse.Subjects != null)
            {
                var subjects = subjectResponse.Subjects.Values.ToList();

                foreach (var subject in subjects)
                {
                    _logger.LogInformation($"Processing subject: {subject}");
                    await ProcessSingleSubject(subject, questionRepository, questionsApi, unitOfWork, cancellationToken);
                }
            }
            else
            {
                _logger.LogWarning("No subjects fetched or status not successful.");
            }
        }

        private async Task ProcessSingleSubject(
            string subject,
            IFreeQuestionRepository questionRepository,
            IGetApiQuestionService questionsApi,
            IUnitOfWorkRepository unitOfWork, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing subject: {subject}");

            try
            {
               /* var sub = await questionRepository.GetSubjectName(subject);
                if(sub is not null)
                {
                    await questionRepository.DeleteOldQuestionsAsync(subject, 40);
                    _logger.LogInformation($"Deleted 40 old questions for subject: {subject}");
                }
                else
                {
                    _logger.LogError($"Unable to delete old questions for subject {subject}");
                    return;
                }*/


            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting old questions for subject {subject}: {ex.Message}");
                return; 
            }

            
            var questionResponse = await questionsApi.GetQuestionsForSubjects(subject);

            if (questionResponse == null || questionResponse.Data == null || !questionResponse.Data.Any())
            {
                _logger.LogWarning($"No valid questions returned for subject: {subject}");
                return;
            }

            /*var questionEntities = questionResponse.Data.Select(q => FreeQuestion.Create(
                questionContent: q.Question,
                subjectName: subject,
                examType: q.ExamType,
                examYear: q.ExamYear,
                imageUrl: q.Image
            )).ToList();*/

            List<FreeQuestion> questionEntities = new();


            foreach (var result in questionResponse.Data)
            {
                var question = FreeQuestion.Create(result.Question,
                                                   subject,
                                                   result.ExamType,
                                                   result.ExamYear,
                                                   result.Image);

                foreach (var option in result.Option.GetType().GetProperties())
                {
                    var optAlpha = option.Name;
                    var optContent = option.GetValue(result.Option);
                    bool isCorrect = optAlpha.Equals(result.Answer, StringComparison.OrdinalIgnoreCase);
                    question.AddOption(question.Id,
                                       optContent.ToString(),
                                       char.Parse(optAlpha),
                                       isCorrect);
                }
                questionEntities.Add(question);
            }


            try
            {
                
                await questionRepository.CreateAsync(questionEntities, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Successfully saved {questionEntities.Count} questions for subject: {subject}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving questions for subject {subject}: {ex.Message}");
            }
        }
    }
}

