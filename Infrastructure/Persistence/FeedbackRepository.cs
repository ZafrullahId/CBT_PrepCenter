using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class FeedbackRepository(CBTDbContext cBTDbContext) : IFeedbackRepository
    {
        public async Task CreateAsync(Feedback feedback, CancellationToken cancellationToken)
        {
            await cBTDbContext.Feedbacks.AddAsync(feedback, cancellationToken);
        }
        public async Task<IReadOnlyList<Feedback>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await cBTDbContext.Feedbacks.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Feedback>> GetAllAsyncId(Guid StudentId, CancellationToken cancellationToken)
        {
            return await cBTDbContext.Feedbacks.Where(x => x.StudentId == StudentId).Include(x => x.Student).ToListAsync(cancellationToken);
        }

        public async Task<Feedback?> GetAsync(Guid feedbackId, CancellationToken cancellationToken)
        {
            return await cBTDbContext.Feedbacks.Where(x => x.Id == feedbackId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
