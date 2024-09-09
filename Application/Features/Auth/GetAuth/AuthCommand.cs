using MediatR;


namespace Application.Features.Auth.GetAuth
{
    public record AuthCommand(string Email,  string Password) : IRequest<AuthCommandResponse>;
}
