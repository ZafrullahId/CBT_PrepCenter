using Microsoft.AspNetCore.Http;

namespace Application.Features.Students.Dtos.Request
{
    public class CreateStudentRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Age { get; set; }
        public string? Base64Image { get; set; }
        public IFormFile? ProfileUpload { get; set; }
    }
}
