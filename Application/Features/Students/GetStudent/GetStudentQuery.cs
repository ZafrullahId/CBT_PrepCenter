using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public record GetStudentQuery(Guid StudentId) : IRequest<GetStudentQueryResponse>;
    
}
