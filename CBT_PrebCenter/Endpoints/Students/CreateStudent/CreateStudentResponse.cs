using CBTPreparation.APIs.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
{
    public record CreateStudentResponse(StudentId StudentId,
        BaseApiResponse BaseResponse);
   
}
