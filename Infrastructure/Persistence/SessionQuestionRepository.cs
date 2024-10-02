using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Persistence.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class SessionQuestionRepository(CBTDbContext context)  :  ISessionQuestionRepository
    {
        public async Task CreateAsync(SessionQuestion result, CancellationToken cancellationToken)
        {
            await context.SessionQuestions.AddAsync(result, cancellationToken);
        }
        public async Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            return await context.SessionQuestions.Where(x => x.CbtSessionId == sessionId).ToListAsync(cancellationToken);
        }
    }
}
