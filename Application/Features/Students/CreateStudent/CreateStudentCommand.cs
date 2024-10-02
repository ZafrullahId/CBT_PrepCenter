using MediatR;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public record CreateStudentCommand(string FirstName, string LastName, string Email, string Password) : IRequest<CreateStudentCommandResponse>;

}
