using CBTPreparation.APIs.Shared;

namespace CBT_PrepCenter.Endpoints.Students.GetStudent
{
    public record GetStudentResponse(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseApiResponse BaseResponse);
}
