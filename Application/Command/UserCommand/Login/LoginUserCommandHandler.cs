using Application.Abstraction.Repositiories;
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
        public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var login = await userRepository.GetAsync(x => x.Email == request.Request.Email && x.Password == request.Request.Password,cancellationToken);
            if (login is null)
            {
                return new AuthResponseDto
                {
                    Message = "Invalid Credentials",
                    Success = false,

                };
            }
            return new AuthResponseDto
            {
                Message = "Login Successfully",
                Success = true,

            };
                    
        }
    }
}
