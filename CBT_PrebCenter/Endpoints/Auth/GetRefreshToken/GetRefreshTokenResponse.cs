using Application.Shared;

namespace CBT.APIs.Endpoints.Auth.GetToken
{
    public record GetRefreshTokenResponse(string Token, string RefreshToken, BaseResponse BaseResponse);
}
