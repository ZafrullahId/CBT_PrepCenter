using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Feedback : AuditableEntity
    {
        public string Comment { get; internal set; } = default!;
        public Guid StudentId { get; internal set; }
        public Student? Student { get; set; }
        internal Feedback(Guid studentId, string comment)
        {
            StudentId = studentId;
            Comment = comment;
        }
        public static Feedback Create(Guid studentId, string comment)
        {
            var feedBack = new Feedback(studentId,comment);
            return feedBack;
        }
    }
}
