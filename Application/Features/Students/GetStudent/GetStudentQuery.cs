using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public record GetStudentQuery(StudentId StudentId) : IRequest<GetStudentQueryResponse>;
    
}
