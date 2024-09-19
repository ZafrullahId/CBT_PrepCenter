using Application.Abstractions.Repositories;
using Domain.Entity;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence
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
    }
}
