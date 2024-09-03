using Application.Features.UserManagement.Dtos.RequestModel;
using Application.Features.UserManagement.Dtos.ResponseModel;
using MediatR;


namespace Application.Features.UserManagement.Command
{
    public record LoginUserCommand(LoginUserRequestModel Request) : IRequest<AuthResponseDto>
    {
    }
}
