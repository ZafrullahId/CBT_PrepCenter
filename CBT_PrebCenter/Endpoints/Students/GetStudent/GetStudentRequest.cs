using Microsoft.AspNetCore.Mvc;

namespace CBT_PrepCenter.Endpoints.Students.GetStudent
{
    public record GetStudentRequest([FromRoute(Name = "student-id")] Guid StudentId);
}
