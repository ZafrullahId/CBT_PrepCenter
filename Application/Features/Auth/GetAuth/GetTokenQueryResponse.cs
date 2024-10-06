using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Auth.GetAuth
{
    public record GetTokenQueryResponse(BaseResponse BaseResponse, string? Token = null, string? RefreshToken = null);
}
