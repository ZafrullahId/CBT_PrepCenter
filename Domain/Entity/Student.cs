using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Student : AuditableEntity
    {
        public Guid UserId { get; private set; }
        public IEnumerable<Feedback> Feedbacks { get; set; } = [];
        public IEnumerable<CbtSession> Sessions { get; set; } = [];
        public IEnumerable<Subject> Subjects { get; set; } = [];

        private Student(User user)
        {
            UserId = user.Id;
        }
        public static Student Create(User user)
        {
            var student = new Student(user);
            return student;
        }
    }
}
