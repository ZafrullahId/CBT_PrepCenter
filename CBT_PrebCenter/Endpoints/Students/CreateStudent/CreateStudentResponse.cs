using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
{
    public record CreateStudentResponse(Guid StudentId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseApiResponse BaseResponse);
   
}
