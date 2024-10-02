using Domain.Entity;

namespace CBTPreparation.Application.Abstractions.Repositories
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student, CancellationToken cancellationToken);
        Task<Student?> GetAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<Student>> GetAllAsync(CancellationToken cancellationToken);
    }
}
