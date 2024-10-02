﻿using Domain.Entity;
using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Persistence.Context;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class FreeQuestionRepository(CBTDbContext context)  : IFreeQuestionRepository
    {
        public async Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken)
        {
            await context.FreeQuestions.AddRangeAsync(result, cancellationToken);
        }
        public async Task<IReadOnlyList<SessionQuestion>> GetAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
