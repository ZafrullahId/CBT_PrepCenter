using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class StudentDto
    {
        public int Age { get; set; }
        public string? Base64Image { get; set; }
        public UserDto? User { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; } = [];
        public IEnumerable<CbtSession> Sessions { get; set; } = [];
        public IEnumerable<Subject> Subjects { get; set; } = [];
    }
}
