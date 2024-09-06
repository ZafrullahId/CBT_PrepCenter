using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositiories
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
    }
}
