using Application.Abstraction.Repositiories;
using Domain.Entity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
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
            return await context.Users.Where(x => x.Email == user.Email &&  x.Password == user.Password).FirstOrDefaultAsync(cancellationToken);
        }


    }
}
