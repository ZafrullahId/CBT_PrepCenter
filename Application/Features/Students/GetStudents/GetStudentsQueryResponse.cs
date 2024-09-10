using Application.Features.Students.GetStudent;
using Application.Shared;

namespace Application.Features.Students.GetStudents
{
    public record GetStudentsQueryResponse(List<GetStudentQueryResponse> Students,
    BaseResponse BaseResponse);
}
