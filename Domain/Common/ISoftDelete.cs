﻿using System;

namespace Domain.Common
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        Guid? DeletedBy { get; set; }
        bool  IsDeleted { get; set; }  
    }
}
