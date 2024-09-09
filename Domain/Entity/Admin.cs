using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Admin : AuditableEntity
    {
        public Guid UserId { get; private set; }
        public Admin(Guid userId)
        {
            UserId = userId;
        }
        public static Admin Create(Guid userId)
        {
            return new Admin(userId);
        }
    }
}
