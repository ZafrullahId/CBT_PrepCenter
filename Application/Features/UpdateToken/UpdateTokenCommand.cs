using MediatR;

namespace CBTPreparation.Application.Features.UpdateToken
{
    public record UpdateTokenCommand(string Token, string RefreshToken) : IRequest<UpdateTokenCommandResponse>;
}
