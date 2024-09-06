﻿using Application.Abstraction.Repositiories;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkRepository(CBTDbContext cBTDbContext) : IUnitOfWorkRepository
    {
        public async Task SaveChangesAsync()
        {
            await cBTDbContext.SaveChangesAsync();
        }
    }
}