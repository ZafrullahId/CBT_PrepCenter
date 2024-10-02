using Domain.Entity;

namespace CBTPreparation.Application.Abstractions.Repositories;
public interface IFreeQuestionRepository
{
    Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken);
}