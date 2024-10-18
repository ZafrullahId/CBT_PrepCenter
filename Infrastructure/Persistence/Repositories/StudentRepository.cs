using CBTPreparation.Domain;
using CBTPreparation.Domain.CourseAggregate;
using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CBTPreparation.Infrastructure.Persistence.Repositories
{
    public class StudentRepository(CBTDbContext context) : IStudentRepository
    {
        public async Task CreateStudentAsync(Student student, CancellationToken cancellationToken)
        {
            await context.Students.AddAsync(student, cancellationToken);
        }
        public Task<Student?> GetStudentAsync(StudentId studentId, CancellationToken cancellationToken)
        {
            return context.Students
               .FirstOrDefaultAsync(x => x.Id == studentId, cancellationToken);
        }
        public async Task<List<StudentWithUserDto>> GetAllStudentAsync(CancellationToken cancellationToken)
        {
            //var test = (from student in context.Students.AsNoTracking() select student).ToList();
            //join user in context.Users.AsNoTracking()
            //on student.UserId equals user.Id select student as IEnumerable<Student>;
            var students = await (from student in context.Students.AsNoTracking()
                                  join user in context.Users.AsNoTracking()
                                  on student.UserId equals user.Id
                                  select new StudentWithUserDto
                                  (
                                      student.Id,
                                      user.FirstName,
                                      user.LastName,
                                      user.Email,
                                      student.Department.Name,
                                      new List<CourseId>()
                                  )).ToListAsync();

            return students;
        }

        public async Task<IReadOnlyList<Feedback>> GetAllFeedbacksAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await context.Students.AsNoTracking()
            //                             .SelectMany(x => x.Feedbacks)
            //                             .OrderByDescending(x => x.CreatedOn)
            //                             .ToListAsync(cancellationToken);
        }

        public async Task<Feedback?> GetFeedbackByIdAsync(FeedbackId feedbackId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await context.Students.SelectMany(x => x.Feedbacks)
            //                             .Where(x => x.Id == feedbackId)
            //                             .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Feedback>> GetAllFeedbackByStudentIdAsync(StudentId studentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await context.Students.Where(x => x.Id == studentId)
            //                             .SelectMany(x => x.Feedbacks)
            //                             .ToListAsync(cancellationToken);
        }
        public async Task<bool> HasCourseAsync(CourseId courseId, CancellationToken cancellationToken)
        {
            return await context.Courses.AnyAsync(x => x.Id == courseId, cancellationToken);
        }
        public async Task<Course?> GetCourseAsync(CourseId courseId, CancellationToken cancellationToken)
        {
            return await context.Courses
                .FirstOrDefaultAsync(x => x.Id == courseId, cancellationToken);
        }
    }
}
