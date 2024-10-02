using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public record CreateStudentCommandResponse(
        Guid StudentId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseResponse BaseResponse);
}
