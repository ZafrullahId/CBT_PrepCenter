namespace Application.Abstraction.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}