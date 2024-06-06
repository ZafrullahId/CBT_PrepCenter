using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Feedback : AuditableEntity
    {
        public string Comment { get; set; } = default!;
        public Guid? StudentId { get; set; }
    }
}
