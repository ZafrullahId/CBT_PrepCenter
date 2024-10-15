using CBTPreparation.APIs.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
{
    public record CreateStudentResponse(Guid StudentId,
        BaseApiResponse BaseResponse);
   
}
