using CBTPreparation.Domain.CbtSessionAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class CbtSessionRepository(CBTDbContext context) : ICbtSessionRepository
    {
        public async Task CreateCbtSessionAsync(CbtSession cbtSession, CancellationToken cancellationToken)
        {
            await context.CbtSessions.AddAsync(cbtSession, cancellationToken);
        }
        public async Task<IReadOnlyList<CbtSession>> GetAllCbtSessionAsync(StudentId studentId, CancellationToken cancellationToken)
        {
            return await context.CbtSessions.AsNoTracking()
                                            .Where(x => x.StudentId == studentId)
                                            .ToListAsync(cancellationToken);
        }
        public async Task<CbtSession?> GetCbtSessionAsync(CbtSessionId sessionId, CancellationToken cancellationToken)
        {
            return await context.CbtSessions.FirstOrDefaultAsync(x => x.Id == sessionId, cancellationToken);
        }
        public async Task<IReadOnlyList<SessionQuestion>> GetSessionQuestionsAsync(CbtSessionId cbtSessionId, CancellationToken cancellationToken)
        {
            return await context.CbtSessions.AsNoTracking()
                                            .Where(x => x.Id == cbtSessionId)
                                            .SelectMany(x => x.SessionQuestions)
                                            .ToListAsync(cancellationToken);
        }
    }
}
