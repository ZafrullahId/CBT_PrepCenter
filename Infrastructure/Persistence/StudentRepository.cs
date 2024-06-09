using Domain.Entity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class StudentRepository(CBTDbContext context)
    {
        public async Task CreateAsync(Student student, CancellationToken cancellationToken)
        {
            await context.Students.AddAsync(student, cancellationToken);
        }
        public async Task<Student?> GetAsync(string userId, CancellationToken cancellationToken)
        {
            return await context.Students.Where(x => x.User.Id == userId).Include(x => x.User).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Students.ToListAsync(cancellationToken);
        }
        // User Repo
        // Role
    }
}
