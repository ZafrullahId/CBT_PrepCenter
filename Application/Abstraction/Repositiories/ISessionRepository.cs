﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface ISessionRepository
    {
        Task CreateAsync(CbtSession cbtSession, CancellationToken cancellationToken);
        Task<IReadOnlyList<CbtSession>> GetAllAsync(Guid studentId, CancellationToken cancellationToken);
        Task<CbtSession?> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
