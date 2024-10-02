using Microsoft.AspNetCore.Http;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
{
    public record CreateStudentRequest(string FirstName, string LastName, string Email, string Password);
}
