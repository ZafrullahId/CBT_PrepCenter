using Application.Shared;

namespace Application.Features.Auth.GetAuth
{
    public record AuthCommandResponse(string Token, string RefreshToken, BaseResponse BaseResponse);
}
