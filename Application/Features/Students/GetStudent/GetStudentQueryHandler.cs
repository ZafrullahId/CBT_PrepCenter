using Application.Abstractions.Repositories;
using Application.Shared;
using MediatR;

namespace Application.Features.Students.GetStudent
{
    public class GetStudentQueryHandler(IStudentRepository _studentRepository) : IRequestHandler<GetStudentQuery, GetStudentQueryResponse>
    {
        public async Task<GetStudentQueryResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var stud = await _studentRepository.GetAsync(request.StudentId, cancellationToken);

            if (stud == null) { throw new NotFoundStudentException(); }

            return new GetStudentQueryResponse(
               stud.User.FirstName,
               stud.User.LastName,
               stud.User.Email,
                new BaseResponse(
                "Student Retrived Successfully",
                true));
        }
    }
}
