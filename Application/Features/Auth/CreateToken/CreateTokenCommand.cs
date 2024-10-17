using MediatR;


namespace CBTPreparation.Application.Features.Auth.CreateToken
{
    public record CreateTokenCommand(string Email, string Password) : IRequest<CreateTokenCommandResponse>;
}
