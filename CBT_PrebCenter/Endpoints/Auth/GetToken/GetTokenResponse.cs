using Application.Shared;

namespace CBT.APIs.Endpoints.Auth.GetToken
{
    public record GetTokenResponse(string Token, string RefreshToken, BaseResponse BaseResponse);
}
