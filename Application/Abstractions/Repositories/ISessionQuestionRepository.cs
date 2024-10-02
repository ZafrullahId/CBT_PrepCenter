using Domain.Entity;

namespace CBTPreparation.Application.Abstractions.Repositories
{
    public interface ISessionQuestionRepository
    {
        Task CreateAsync(SessionQuestion result, CancellationToken cancellationToken);
        Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken);
    }
}
