using MediatR;

namespace CBTPreparation.Application.Features.Auth.UpdateToken
{
    public record UpdateTokenCommand(string Token, string RefreshToken) : IRequest<UpdateTokenCommandResponse>;
}
