using CBTPreparation.Domain;
using CBTPreparation.Infrastructure.Persistence.Context;

namespace CBTPreparation.Infrastructure.Persistence.Repositories
{
    public class UnitOfWorkRepository(CBTDbContext cBTDbContext) : IUnitOfWorkRepository
    {
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await cBTDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
