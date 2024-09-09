
using CBT_PrepCenter.Endpoints.Shared;

namespace CBT_PrepCenter.Endpoints.Students.CreateStudent
{
    public record CreateStudentResponse(Guid StudentId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        BaseResponse BaseResponse);
   
}
