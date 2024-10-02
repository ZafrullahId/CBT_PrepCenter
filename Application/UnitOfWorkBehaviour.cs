using CBTPreparation.Application.Abstractions.Repositories;
using MediatR;

namespace CBTPreparation_Infrastructure.Persistence
{
    public sealed class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public UnitOfWorkBehaviour(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (IsNotCommand())
            {
                return await next();
            }

            var response = await next();

            await _unitOfWorkRepository.SaveChangesAsync(cancellationToken);

            return response;
        }

        private static bool IsNotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Command");
        }
    }
}
