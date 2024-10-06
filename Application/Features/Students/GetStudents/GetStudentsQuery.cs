using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudents
{
    public record GetStudentsQuery()  : IRequest<GetStudentsQueryResponse>;
}
