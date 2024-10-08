using System.Linq.Expressions;

namespace CBTPreparation.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetUserAsync(UserId userId, CancellationToken cancellationToken);
        Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken);
    }
}
