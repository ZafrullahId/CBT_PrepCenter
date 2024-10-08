﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface IFeedbackRepository
    {
        Task CreateAsync(Feedback feedback, CancellationToken cancellationToken);
        Task<IReadOnlyList<Feedback>> GetAllAsync(CancellationToken cancellationToken);
    }
}
