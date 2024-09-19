using Application.Shared;

namespace Application.Features.Auth.GetAuth
{
    public record GetTokenQueryResponse(string Token, string RefreshToken, BaseResponse BaseResponse);
}
