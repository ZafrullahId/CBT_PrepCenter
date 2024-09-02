using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student, CancellationToken cancellationToken);
        Task<Student?> GetAsync(string userId, CancellationToken cancellationToken);
        Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken);
    }
}
