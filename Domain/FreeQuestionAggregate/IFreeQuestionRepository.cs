using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPreparation.Domain.FreeQuestionAggregate
{
    public interface IFreeQuestionRepository
    {
        Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken);
    }
}
