using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken
{
    public record GetTokenResponse(string Token, string RefreshToken, BaseApiResponse BaseResponse);
}
