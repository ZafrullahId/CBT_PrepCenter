using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.GoogleAuth
{
    public record GoogleAuthCommandResponse(
        string Token, 
        string RefreshToken,
        BaseResponse BaseResponse);
}
