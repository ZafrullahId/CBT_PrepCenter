using CBTPreparation.Domain.FreeQuestionAggregate;

namespace CBTPreparation.Application.Abstractions.Repositories;
public interface IFreeQuestionRepository
{
    Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken);
}