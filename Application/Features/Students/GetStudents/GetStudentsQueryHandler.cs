using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Students.GetStudents
{
    public class GetStudentsQueryHandler(IStudentRepository _studentRepository) : IRequestHandler<GetStudentsQuery, List<GetStudentsQueryResponse>>
    {
        public async Task<List<GetStudentsQueryResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var stud = await _studentRepository.GetAllAsync(cancellationToken);

            return new List<GetStudentsQueryResponse>().ToList();
        }
    }
}
