using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SessionResult : AuditableEntity
    {
        public Guid CbtSessionId { get; set; }
        public char ChosenOption { get; set; }
        public char? CorrectOption { get; set; }
        public CbtSession CbtSession { get; set; }
        public string Question { get; set; } = default!;
        public IEnumerable<Options> Options { get; set; } = [];
        public SessionResult(Guid cbtSessionId, )
        {
            
        }
    }
}
