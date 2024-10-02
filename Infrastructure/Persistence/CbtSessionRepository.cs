using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Persistence.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class CbtSessionRepository(CBTDbContext context) : ICbtSessionRepository
    {
        public async Task CreateAsync(CbtSession cbtSession, CancellationToken cancellationToken)
        {
            await context.CbtSessions.AddAsync(cbtSession, cancellationToken);
        }
        public async Task<IReadOnlyList<CbtSession>> GetAllAsync(Guid studentId, CancellationToken cancellationToken)
        {
            return await context.CbtSessions.Where(x => x.StudentId == studentId).AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<CbtSession?> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            return await context.CbtSessions.FirstOrDefaultAsync(x => x.Id == sessionId, cancellationToken);
        }
    }
}
