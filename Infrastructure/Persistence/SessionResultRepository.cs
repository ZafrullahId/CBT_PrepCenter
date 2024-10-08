﻿using Application.Abstraction.Repositories;
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
    public class SessionResultRepository(CBTDbContext context)  :  ISessionResultRepository
    {
        public async Task CreateAsync(SessionResult result, CancellationToken cancellationToken)
        {
            await context.SessionResults.AddAsync(result, cancellationToken);
        }
        public async Task<IReadOnlyList<SessionResult>> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            return await context.SessionResults.Where(x => x.CbtSessionId == sessionId).ToListAsync(cancellationToken);
        }
    }
}
