using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public interface ICbtSessionRepository
    {
        Task CreateCbtSessionAsync(CbtSession cbtSession, CancellationToken cancellationToken);
        Task<IReadOnlyList<CbtSession>> GetAllCbtSessionAsync(StudentId studentId, CancellationToken cancellationToken);
        Task<CbtSession?> GetCbtSessionAsync(CbtSessionId sessionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SessionQuestion>> GetSessionQuestionsAsync(CbtSessionId sessionId, CancellationToken cancellationToken);
    }
}
