﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Admin : AuditableEntity
    {
        public Guid UserId { get; set; }
        public User User {  get; set; } 
    }
}
