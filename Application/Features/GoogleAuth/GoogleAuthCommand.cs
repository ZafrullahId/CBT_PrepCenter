using MediatR;


namespace Application.Features.GoogleAuth
{
    public record GoogleAuthCommand(string  IdToken) : IRequest<GoogleAuthResponse>;
}
