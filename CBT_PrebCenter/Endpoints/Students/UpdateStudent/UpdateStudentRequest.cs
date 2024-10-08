using CBTPreparation.Domain.StudentAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Students.UpdateStudent
{
    public record UpdateStudentRequestModel([FromRoute(Name = "student-id")] Guid StudentId, [FromBody] UpdateStudentRequest body);
    public record UpdateStudentRequest(string FirstName, string LastName, string Department, List<Course> Courses);
}
