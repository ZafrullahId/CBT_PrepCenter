using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student, CancellationToken cancellationToken);
        Task<Student?> GetAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<Student>> GetAllAsync(CancellationToken cancellationToken);
    }
}
