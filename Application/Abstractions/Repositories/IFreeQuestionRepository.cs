using Domain.Entity;

namespace Application.Abstractions.Repositories;
public interface IFreeQuestionRepository
{
    Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken);
}