using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Persistence.Context;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class UnitOfWorkRepository(CBTDbContext cBTDbContext) : IUnitOfWorkRepository
    {
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await cBTDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
