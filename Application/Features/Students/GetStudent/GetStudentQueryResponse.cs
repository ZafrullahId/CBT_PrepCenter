using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public record GetStudentQueryResponse(StudentId StudentId,
                                          string FirstName,
                                          string LastName,
                                          string Email,
                                          string Department,
                                          IEnumerable<string> Courses,
                                          BaseResponse BaseResponse);
}
