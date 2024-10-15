using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Abstractions.Repositories
{
    public interface IFeedbackRepository
    {
        Task CreateAsync(Feedback feedback, CancellationToken cancellationToken);
        Task<IReadOnlyList<Feedback>> GetAllAsync(CancellationToken cancellationToken);
        Task<Feedback?> GetAsync(FeedbackId feedbackId, CancellationToken cancellationToken);
        Task<IReadOnlyList<Feedback>> GetAllAsyncId(StudentId StudentId, CancellationToken cancellationToken);
    }
}
