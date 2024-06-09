﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set;} = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Admin Admin { get; set; }
        public Student Student { get; set; }   
    }
}
