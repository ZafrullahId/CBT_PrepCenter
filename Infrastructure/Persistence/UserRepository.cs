﻿using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class UserRepository(CBTDbContext context) : IUserRepository
    {
        public  async Task CreateAsync(User user, CancellationToken cancellationToken)
        {
            await context.Users.AddAsync(user, cancellationToken);
        }

        public  async Task<User?> GetAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken)
        {
            return await context.Users
                 .Where(expression)
                 .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User?> LoginAsync(User user, CancellationToken cancellationToken)
        {
            return await context.Users.Where(x => x.Email == user.Email &&  x.PasswordHash == user.PasswordHash).FirstOrDefaultAsync(cancellationToken);
        }


    }
}
