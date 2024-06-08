using Application.Abstraction.Repositiories.IRepository;
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
    public class UserRepository(CBTDbContext context)   :  IUserRepository
    {
        public async Task<User?> LoginAsync(User  user, CancellationToken cancellationToken)
        {
            return await context.Users.Where(x=>x.Email==user.Email && x.Password== user.Password).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
