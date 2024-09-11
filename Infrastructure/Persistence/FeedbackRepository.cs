using Application.Abstractions.Repositories;
using Domain.Entity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
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

        public async Task<Feedback?> GetAsync(Guid feedbackId, CancellationToken cancellationToken)
        {
            return await cBTDbContext.Feedbacks.Where(x => x.Id == feedbackId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
