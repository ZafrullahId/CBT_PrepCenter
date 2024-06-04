﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Jwt
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;

        public int TokenExpirationInMinutes { get; set; }

        public int RefreshTokenExpirationInDays { get; set; }
    }
}
