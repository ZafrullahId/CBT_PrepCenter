using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CBTPreparation.Infrastructure.Persistence.Repositories
{
    public class FeedbackRepository(CBTDbContext context) : IFeedbackRepository
    {

        public async Task CreateAsync(Feedback feedback, CancellationToken cancellationToken)
        {
            await context.Feedbacks.AddAsync(feedback, cancellationToken);
        }

        public async Task<IReadOnlyList<Feedback>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Feedbacks.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Feedback>> GetAllAsyncId(StudentId studentId, CancellationToken cancellationToken)
        {
            return await context.Feedbacks.Where(x => x.StudentId == studentId).ToListAsync(cancellationToken);
        }

        public async Task<Feedback?> GetAsync(FeedbackId feedbackId, CancellationToken cancellationToken)
        {
            return await context.Feedbacks.Where(x => x.Id == feedbackId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
