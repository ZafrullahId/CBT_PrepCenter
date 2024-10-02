using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Persistence.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence
{
    public class StudentRepository(CBTDbContext context) : IStudentRepository
    {
        public async Task CreateAsync(Student student, CancellationToken cancellationToken)
        {
            await context.Students.AddAsync(student, cancellationToken);
        }
        public async Task<Student?> GetAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await context.Students.Where(x => x.UserId == userId).Include(x => x.User).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<List<Student>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Students.ToListAsync(cancellationToken);
        }
        // User Repo
        // Role
    }
}
