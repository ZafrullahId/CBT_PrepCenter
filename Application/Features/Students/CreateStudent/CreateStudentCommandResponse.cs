using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public record CreateStudentCommandResponse(
        StudentId StudentId,
        BaseResponse BaseResponse);
}
