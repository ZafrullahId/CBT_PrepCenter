using Application.Shared;

namespace CBT.APIs.Endpoints.GoogleAuth
{
    public record GoogleAuthResponseEndpoint(
        string Token,
        string RefreshToken,
        BaseResponse BaseResponse);
}
