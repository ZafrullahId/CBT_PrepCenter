using CBTPreparation.Domain.UserAggregate;
using System.Linq.Expressions;

namespace CBTPreparation.Domain.AdminAggregate
{
    public interface IAdminRepository
    {
        Task CreateAsync(Admin admin, CancellationToken cancellationToken);
        Task<Admin?> GetAsync(AdminId adminId, CancellationToken cancellationToken);
        Task<Admin?> GetAllAsync(CancellationToken cancellationToken);
        Task RemoveAsync(AdminId adminId, CancellationToken cancellationToken);
    }
}
