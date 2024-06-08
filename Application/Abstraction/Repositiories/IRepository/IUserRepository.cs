using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositiories.IRepository
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
    }
}
