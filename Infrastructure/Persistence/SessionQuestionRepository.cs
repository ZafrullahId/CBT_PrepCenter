using Application.Abstractions.Repositories;
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
