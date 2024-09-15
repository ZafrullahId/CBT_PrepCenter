using MediatR;


namespace Application.Features.GoogleAuth
{
    public record GoogleLoginCommand(string  IdToken) : IRequest<GoogleLoginResponse>;
}
