using CBTPreparation.Infrastructure.Persistence.Context;
using CBTPreparation.Domain.CbtSessionAggregate;
using CBTPreparation.Domain.FreeQuestionAggregate;

namespace CBTPreparation.Infrastructure.Persistence.Repositories
{
    public class FreeQuestionRepository(CBTDbContext context) : IFreeQuestionRepository
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
