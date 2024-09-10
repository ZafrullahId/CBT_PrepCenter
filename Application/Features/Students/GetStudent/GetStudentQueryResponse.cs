using Application.Shared;

namespace Application.Features.Students.GetStudent
{
    public record GetStudentQueryResponse(
    string FirstName,
    string LastName,
    string Email,
    BaseResponse BaseResponse);
}
