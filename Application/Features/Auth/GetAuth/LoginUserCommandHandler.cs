using Application.Abstraction.Repositories;
using Application.Features.Auth.Dtos.Response;
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
