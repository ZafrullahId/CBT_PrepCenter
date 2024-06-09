using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CbtSession : AuditableEntity
    {
        public double Score { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestion { get; set; }
        public int NumberOfWrongAnswers { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public SessionResult SessionResult { get; set; }
    }
}
