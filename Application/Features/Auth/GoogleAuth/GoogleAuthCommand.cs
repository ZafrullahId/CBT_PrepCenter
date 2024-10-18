using MediatR;


namespace CBTPreparation.Application.Features.Auth.GoogleAuth
{
    public record GoogleAuthCommand(string IdToken) : IRequest<GoogleAuthCommandResponse>;
}
