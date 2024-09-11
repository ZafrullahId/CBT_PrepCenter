using Application.Shared;
using CBT.APIs.Shared;

namespace CBT_PrepCenter.Endpoints.Students.GetStudents
{
    public record GetStudentsResponse(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseApiResponse BaseResponse);
}
