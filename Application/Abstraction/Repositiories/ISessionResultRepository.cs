using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface ISessionResultRepository
    {
        Task CreateAsync(SessionResult result, CancellationToken cancellationToken);
        Task<IReadOnlyList<SessionResult>> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
