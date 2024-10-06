namespace CBTPreparation.Domain
{
    public interface IUnitOfWorkRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}