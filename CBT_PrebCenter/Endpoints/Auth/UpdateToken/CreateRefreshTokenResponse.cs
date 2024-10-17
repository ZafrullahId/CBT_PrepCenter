using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Auth.UpdateToken
{
    public record CreateRefreshTokenResponse(string Token, string RefreshToken, BaseApiResponse BaseResponse);
}
