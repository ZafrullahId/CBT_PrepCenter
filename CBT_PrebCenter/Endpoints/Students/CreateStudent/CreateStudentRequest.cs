using Microsoft.AspNetCore.Http;

namespace CBT_PrepCenter.Endpoints.Students.CreateStudent
{
    public record CreateStudentRequest(string FirstName, string LastName, string Email, string Password);
}
