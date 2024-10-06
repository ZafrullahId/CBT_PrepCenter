using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Auth.UpdateToken
{
    public record GetRefreshTokenResponse(string Token, string RefreshToken, BaseApiResponse BaseResponse);
}
