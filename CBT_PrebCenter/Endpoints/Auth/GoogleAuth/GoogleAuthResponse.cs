using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Auth.GoogleAuth
{
    public record GoogleAuthResponse(
        string Token,
        string RefreshToken,
        BaseApiResponse BaseResponse);
}
