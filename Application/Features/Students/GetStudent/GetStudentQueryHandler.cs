using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public class GetStudentQueryHandler(IStudentRepository _studentRepository, IUserRepository _userRepository) : IRequestHandler<GetStudentQuery, GetStudentQueryResponse>
    {
        public async Task<GetStudentQueryResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentAsync(request.StudentId, cancellationToken);

            if (student is { })
            {
                var studentUser = await _userRepository.GetUserAsync(x => x.Id == student.UserId, cancellationToken);

                return new GetStudentQueryResponse(
                               student.Id,
                               studentUser.FirstName,
                               studentUser.LastName,
                               studentUser.Email,
                               student.Department.Name,
                               student.CoursesIds.Select(async x => await _studentRepository
                               .GetCourseAsync(x, cancellationToken)).Select(x => x.Result.Name),
                                new BaseResponse(
                                "Student Retrieved Successfully",
                                true));
            }

            throw new StudentNotFoundException(request.StudentId);
        }
    }
}
