using Application.Features.UserManagement.Dtos;
using Domain.Entity;

namespace Application.Features.Students.Dtos
{
    public class StudentDto
    {
        public int Age { get; set; }
        public UserDto? User { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; } = [];
        public IEnumerable<CbtSession> Sessions { get; set; } = [];
    }
}
