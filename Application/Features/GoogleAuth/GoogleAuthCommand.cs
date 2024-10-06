using MediatR;


namespace CBTPreparation.Application.Features.GoogleAuth
{
    public record GoogleAuthCommand(string  IdToken) : IRequest<GoogleAuthResponse>;
}
