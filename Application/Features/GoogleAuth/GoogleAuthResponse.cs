using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.GoogleAuth
{
    public record GoogleAuthResponse(
        string Token, 
        string RefreshToken,
        BaseResponse BaseResponse);
}
