using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositiories.IRepository
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student, CancellationToken cancellationToken);
        Task<Student?> GetAsync(Guid userId, CancellationToken cancellationToken);
        Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken);
    }
}
