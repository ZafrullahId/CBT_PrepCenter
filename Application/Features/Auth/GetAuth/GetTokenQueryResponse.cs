using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Auth.GetAuth
{
    public record GetTokenQueryResponse(string Token, string RefreshToken, BaseResponse BaseResponse);
}
