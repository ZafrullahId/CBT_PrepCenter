using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.UpdateToken
{
    public record UpdateTokenCommandResponse(BaseResponse BaseResponse, string? Token = null, string? RefreshToken = null);
}
