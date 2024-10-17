using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.UserAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.UpdateToken
{
    public class UpdateTokenCommandHandler(ITokenProvider _tokenProvider, IUserRepository _userRepository) : IRequestHandler<UpdateTokenCommand, UpdateTokenCommandResponse>
    {
        public Task<UpdateTokenCommandResponse> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = _tokenProvider.GetPrincipalFromExpiredToken(request.Token);

            var token = _tokenProvider.CreateRefresh(principal.Claims);

            return Task.FromResult(new UpdateTokenCommandResponse(new BaseResponse(
                "Token Successfully Refreshed",
                true), token, request.RefreshToken));
        }
    }
}
