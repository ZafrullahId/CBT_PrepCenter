using Application.Shared;

namespace Application.Features.GoogleAuth
{
    public record GoogleAuthResponse(
        string Token, 
        string RefreshToken,
        BaseResponse BaseResponse);
}
