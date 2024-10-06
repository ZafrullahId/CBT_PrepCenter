using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Students.GetStudents
{
    public record GetStudentsQueryResponse(List<GetStudentQueryResponse> Students,
                                           BaseResponse BaseResponse);
}
