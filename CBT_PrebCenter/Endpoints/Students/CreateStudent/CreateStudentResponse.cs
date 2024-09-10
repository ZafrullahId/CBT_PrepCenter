
using CBT.APIs.Endpoints.Shared;

namespace CBT.APIs.Endpoints.Students.CreateStudent
{
    public record CreateStudentResponse(Guid StudentId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseResponse BaseResponse);
   
}
