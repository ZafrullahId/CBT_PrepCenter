using Domain.Entity;

namespace CBTPreparation.Application.Abstractions.Repositories
{
    public interface ICbtSessionRepository
    {
        Task CreateAsync(CbtSession cbtSession, CancellationToken cancellationToken);
        Task<IReadOnlyList<CbtSession>> GetAllAsync(Guid studentId, CancellationToken cancellationToken);
        Task<CbtSession?> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
