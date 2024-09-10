using Application.Shared;

namespace Application.Features.Students.GetStudents
{
    public record GetStudentsQueryResponse(
    string FirstName,
    string LastName,
    string Email,
    BaseResponse BaseResponse);
}
