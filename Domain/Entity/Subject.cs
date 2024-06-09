using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Subject : AuditableEntity
    {
        public string Name { get; set; } = default!;
        public IEnumerable<Student> Students { get; set; } = [];
    }
}
