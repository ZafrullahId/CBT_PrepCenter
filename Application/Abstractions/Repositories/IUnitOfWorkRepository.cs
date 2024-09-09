namespace Application.Abstractions.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}