using CBTPreparation.Infrastructure.Persistence.Context;
using CBTPreparation.Domain.CbtSessionAggregate;
using CBTPreparation.Domain.FreeQuestionAggregate;
using CBTPreparation.Application.Abstractions.ApplicationService.ExternalDto;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class FreeQuestionRepository(CBTDbContext context)  : IFreeQuestionRepository
    {
        public async Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken)
        {
            await context.FreeQuestions.AddRangeAsync(result, cancellationToken);
        }
        public async Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOldQuestionsAsync(string subject, int numberToDelete)
        {
            
                var questionsToDelete = await context.FreeQuestions
                    .Where(q => q.SubjectName == subject)
                    .OrderBy(q => q.CreatedOn)
                    .Take(numberToDelete)
                    .ToListAsync();

                if (questionsToDelete.Any())
                {
                    context.FreeQuestions.RemoveRange(questionsToDelete);
                    await context.SaveChangesAsync();
                    //_log.LogInformation($"Successfully deleted {questionsToDelete.Count} questions for subject: {subject}");
                }
                else
                {
                    //_log.LogError($"No questions found to delete for subject: {subject}");
                }
        }

        public async Task<FreeQuestion> GetSubjectName(string subjectName)
        {
            /*var subject = await context.FreeQuestions
            .Where(x => x.SubjectName == subjectName)
            .FirstOrDefaultAsync();
            return subject.SubjectName;*/
            return await context.FreeQuestions
            .Where(x => x.SubjectName == subjectName)
            .FirstOrDefaultAsync();
        }

    }
}
