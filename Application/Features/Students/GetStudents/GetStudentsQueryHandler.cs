using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Domain.StudentAggregate;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudents
{
    public class GetStudentsQueryHandler(IStudentRepository _studentRepository, IMapper _mapper) : IRequestHandler<GetStudentsQuery, GetStudentsQueryResponse>
    {
        public async Task<GetStudentsQueryResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllStudentAsync(cancellationToken);

            if (students is { Count: > 0 })
                return new GetStudentsQueryResponse(_mapper.Map<List<GetStudentQueryResponse>>(students),
                                                    new Shared.BaseResponse("Students Successfully Retrieved", true));

            return new GetStudentsQueryResponse([], new Shared.BaseResponse("No Student Yet", false));
        }
    }
}
