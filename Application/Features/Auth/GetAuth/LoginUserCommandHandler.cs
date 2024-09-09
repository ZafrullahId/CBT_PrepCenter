using Application.Abstraction.Repositiories.IRepository;
using Application.Features.UserManagement.Command;
using Application.Features.UserManagement.Dtos.ResponseModel;
using MediatR;


namespace Application.Features.Auth.GetAuth
{
    public class LoginUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LoginUserCommand, AuthResponseDto>
    {
        public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(x => x.Email == request.Request.Email && x.Password == request.Request.Password, cancellationToken);
            // we still need to work on JWT here
            if (user is null)
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
