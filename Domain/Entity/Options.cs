using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Options : AuditableEntity
    {
        public char AlphaOpt {  get; set; }
        public string OptContent { get; set; } = default!;
        public Guid SessionResultId { get; set; }
    }
}
