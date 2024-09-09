namespace Application.Abstraction.Repositiories
{
    public interface IUnitOfWorkRepository
    {
        Task SaveChangesAsync();
    }
}