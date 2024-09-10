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
        private readonly List<Feedback> _feedbacks = new();
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks;
        public IEnumerable<CbtSession> Sessions { get; set; } = [];

        private Student(User user)
        {
            UserId = user.Id;
        }
        public static Student Create(User user)
        {
            var student = new Student(user);
            return student;
        }
        public Feedback AddFeedBack(Guid studentId, string comment)
        {
            var feedBack = new Feedback(studentId, comment);
            _feedbacks.Add(feedBack);
            return feedBack;
        }
    }
}
