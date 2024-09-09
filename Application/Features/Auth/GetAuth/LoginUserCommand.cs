using Application.Features.Auth.Dtos.Request;
using Application.Features.Auth.Dtos.Response;
using MediatR;


namespace Application.Features.Auth.GetAuth
{
    public record LoginUserCommand(LoginUserRequestModel Request) : IRequest<AuthResponseDto>
    {
    }
}
