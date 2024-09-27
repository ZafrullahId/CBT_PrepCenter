using Application.Abstractions.Repositories;
using Domain.Entity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class FreeQuestionRepository(CBTDbContext context)  : IFreeQuestionRepository
    {
        public  async Task AddAsync(FreeQuestion question)
        {
            context.FreeQuestions.Add(question);
            await context.SaveChangesAsync();
        }

        public async Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken)
        {
            await context.FreeQuestions.AddRangeAsync(result, cancellationToken);
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
            }
        }

        public async Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
