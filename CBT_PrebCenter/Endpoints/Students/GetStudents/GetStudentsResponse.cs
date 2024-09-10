using Application.Shared;

namespace CBT_PrepCenter.Endpoints.Students.GetStudents
{
    public record GetStudentsResponse(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseResponse BaseResponse);
}
