using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Auth.GoogleAuth
{
    public record GoogleAuthCommandResponse(
        string Token,
        string RefreshToken,
        BaseResponse BaseResponse);
}
