using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public record CreateStudentCommand(string FirstName, string LastName, string Email, string Password, string Department, List<Course> Courses) : IRequest<CreateStudentCommandResponse>;

}
