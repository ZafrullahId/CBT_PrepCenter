using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.UserCommand.Login
{
    public record LoginUserCommand(LoginUserRequestModel Request) : IRequest<AuthResponseDto>
    {
    }
}
