using Application.Abstractions.Repositories;
using Application.Shared;
using MediatR;

namespace Application.Features.Students.GetStudent
{
    public class GetStudentQueryHandler(IStudentRepository _studentRepository) : IRequestHandler<GetStudentQuery, GetStudentQueryResponse>
    {
        public async Task<GetStudentQueryResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAsync(request.StudentId, cancellationToken);

            if (student == null) { throw new StudentNotFoundException(student.Id.ToString()); }

            return new GetStudentQueryResponse(
               student.User.FirstName,
               student.User.LastName,
               student.User.Email,
                new BaseResponse(
                "Student Retrived Successfully",
                true));
        }
    }
}
