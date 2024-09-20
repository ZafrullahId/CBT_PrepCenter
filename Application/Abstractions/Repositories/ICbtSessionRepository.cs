using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ICbtSessionRepository
    {
        Task CreateAsync(CbtSession cbtSession, CancellationToken cancellationToken);
        Task<IReadOnlyList<CbtSession>> GetAllAsync(Guid studentId, CancellationToken cancellationToken);
        Task<CbtSession?> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
