using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Auth.CreateToken
{
    public record CreateTokenCommandResponse(BaseResponse BaseResponse, string? Token = null, string? RefreshToken = null);
}
