using Application.Abstractions.Repositories;
using Application.Features.Students.GetStudent;
using MapsterMapper;
using MediatR;

namespace Application.Features.Students.GetStudents
{
    public class GetStudentsQueryHandler(IStudentRepository _studentRepository, IMapper _mapper) : IRequestHandler<GetStudentsQuery, GetStudentsQueryResponse>
    {
        public async Task<GetStudentsQueryResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync(cancellationToken);

            if (students is { Count: > 0 })
                return new GetStudentsQueryResponse(
                    _mapper.Map<List<GetStudentQueryResponse>>(students.Select(x => x.User).ToList()),
                    new Shared.BaseResponse("Students Successfully Retrieved", true));

            return new GetStudentsQueryResponse([], new Shared.BaseResponse("No Student Yet", false));
        }
    }
}
