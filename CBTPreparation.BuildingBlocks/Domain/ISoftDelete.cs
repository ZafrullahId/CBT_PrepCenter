﻿using System;

namespace CBTPreparation.BuildingBlocks.Domain
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        Guid? DeletedBy { get; set; }
        bool  IsDeleted { get; set; }  
    }
}
