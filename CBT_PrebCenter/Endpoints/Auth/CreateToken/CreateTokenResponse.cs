using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Auth.CreateToken
{
    public record CreateTokenResponse(string Token, string RefreshToken, BaseApiResponse BaseResponse);
}
