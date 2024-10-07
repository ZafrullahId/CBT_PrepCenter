using System.Linq.Expressions;

namespace CBTPreparation.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken);
        Task CreateUserAsync(User user, CancellationToken cancellationToken);
    }
}
