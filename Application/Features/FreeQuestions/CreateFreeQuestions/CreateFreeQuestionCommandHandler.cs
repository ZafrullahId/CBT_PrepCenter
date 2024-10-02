using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Abstractions.Service;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.FreeQuestionAggregate;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions
{
    public class CreateFreeQuestionCommandHandler(IGetApiQuestionService _apiQuestionService, IFreeQuestionRepository _freeQuestionRepository, IMapper _mapper) : IRequestHandler<CreateFreeQuestionCommand, CreateFreeQuestionCommandResponse>
    {
        public async Task<CreateFreeQuestionCommandResponse> Handle(CreateFreeQuestionCommand request, CancellationToken cancellationToken)
        {
            var response = await _apiQuestionService.GetFreeQuestionsAsync(request.Subject);
            if (response.IsSuccessStatusCode)
            {
                List<FreeQuestion> freeQuestions = new();
                var apiResult = response.Content;

                foreach (var result in apiResult.Data)
                {
                    var question = FreeQuestion.Create(result.Question,
                                                       apiResult.Subject,
                                                       result.ExamType,
                                                       result.ExamYear,
                                                       result.Image);

                    foreach (var option in result.Option.GetType().GetProperties())
                    {
                        var optAlpha = option.Name;
                        var optContent = option.GetValue(result.Option);
                        bool isCorrect = optAlpha.Equals(result.Answer, StringComparison.OrdinalIgnoreCase);
                        question.AddOption(optContent.ToString(),
                                           char.Parse(optAlpha),
                                           isCorrect);
                    }
                    freeQuestions.Add(question);
                }
                // check if subject has already 40 questions in the DB
                await _freeQuestionRepository.CreateAsync(freeQuestions,
                                                          cancellationToken);

                // not suppose to return this, this should be in the query method
                var questions = freeQuestions.Select(question => new CreateFreeQuestionDataCommandResponse(
                    question.Id, question.SubjectName, 
                    question.QuestionContent, 
                    question.ExamType, question.ExamYear, 

                    question.ImageUrl, question.FreeOptions.Select(option => new CreateFreeQuestionDataOptionCommandResponse(
                        option.OptionContent, 
                        option.OptionAlpha, 
                        option.ImageUrl)
                    ).ToList())
                ).ToList();

                return new CreateFreeQuestionCommandResponse(
                    questions,
                    new BaseResponse("Question Created Successfully", true));

            }
            throw new FreeQuestionApiCallFailedException(response.RequestMessage.RequestUri.AbsolutePath, response.StatusCode);
        }
    }
}