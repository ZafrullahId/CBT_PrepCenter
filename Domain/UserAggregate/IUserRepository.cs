﻿using System.Linq.Expressions;

namespace CBTPreparation.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
    }
}