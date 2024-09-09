﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositiories
{
    public interface ISessionResultRepository
    {
        Task CreateAsync(SessionQuestion result, CancellationToken cancellationToken);
        Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
