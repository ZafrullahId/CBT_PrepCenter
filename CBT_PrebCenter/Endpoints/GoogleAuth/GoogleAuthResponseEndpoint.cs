using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.GoogleAuth
{
    public record GoogleAuthResponseEndpoint(
        string Token,
        string RefreshToken,
        BaseApiResponse BaseResponse);
}
