using Application.Features.Students.Dtos.Request;
using Application.Features.Students.Dtos.Response;
using MediatR;

namespace Application.Features.Students.Command
{
    public record CreateStudentCommand(CreateStudentRequestModel Model) : IRequest<StudentResponse>;

}
