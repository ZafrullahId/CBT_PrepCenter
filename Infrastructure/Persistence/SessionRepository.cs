using Application.Abstraction.Repositiories;
using Domain.Entity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SessionRepository(CBTDbContext context) : ISessionRepository
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
