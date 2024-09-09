using Application.Shared;

namespace Application.Features.Students.CreateStudent
{
    public record CreateStudentCommandResponse(
        Guid StudentId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseResponse BaseResponse);
}
