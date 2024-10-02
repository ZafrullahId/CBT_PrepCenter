using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public record GetStudentQueryResponse(
    string FirstName,
    string LastName,
    string Email,
    BaseResponse BaseResponse);
}
