using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Model;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Cache;
using MediatR;
using System.Security.Claims;

namespace CBTPreparation.Application.Features.Auth.UpdateToken
{
    public class UpdateTokenCommandHandler(ITokenProvider _tokenProvider, ICacheService _cacheService, IUserRepository _userRepository) : IRequestHandler<UpdateTokenCommand, UpdateTokenCommandResponse>
    {
        public async Task<UpdateTokenCommandResponse> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            var expiredTokenPrincipal = _tokenProvider.GetPrincipalFromToken(request.Token);

            if (expiredTokenPrincipal is null)
            {
                // throw
            }

            var userId = expiredTokenPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            var user = await _userRepository.GetUserAsync(new UserId { Value = Guid.Parse(userId.Value) }, cancellationToken);

            if (user is null)
            {
                // throw
            }

            var storedRefreshToken = _cacheService.GetData<ApplicationUser>(user.Email);

            if (storedRefreshToken is null)
            {
                // throw
            }

            if (storedRefreshToken is null
                || !storedRefreshToken.RefreshToken.Equals(request.RefreshToken)
                || storedRefreshToken.RefreshTokenExpiryTime <= DateTime.Now)
            {
                // throw
            }
            var token = _tokenProvider.Create(expiredTokenPrincipal.Claims);
            var refreshToken = _tokenProvider.GenerateRefreshToken();

            var applicationUser = new ApplicationUser
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };

            _cacheService.RemoveData(user.Email);
            _cacheService.SetData(user.Email, applicationUser, applicationUser.RefreshTokenExpiryTime);

            return new UpdateTokenCommandResponse(new BaseResponse(
                "Token Successfully Refreshed",
                true), token, refreshToken);
        }
    }
}
