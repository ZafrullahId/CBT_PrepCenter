using Application.Abstraction.Repositiories.IRepository;
using Application.Dtos.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.UserCommand.Login
{
    public class LoginUserCommandHandler(IUserRepository  userRepository) : IRequestHandler<LoginUserCommand, AuthResponseDto>
    {
        public Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
