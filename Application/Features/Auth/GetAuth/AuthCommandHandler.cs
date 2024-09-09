using Application.Abstractions.Repositories;
using Application.Shared;
using MediatR;


namespace Application.Features.Auth.GetAuth
{
    public class AuthCommandHandler(IUserRepository userRepository) : IRequestHandler<AuthCommand, AuthCommandResponse>
    {
        public async Task<AuthCommandResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken);
            // we still need to work on JWT here
            if (user is null)
            {
                return new AuthCommandResponse("", "", new BaseResponse("Invalid Credentials", false));
            }
            return new AuthCommandResponse("", "", new BaseResponse("Successfully LoggedIn", false));

        }
    }
}
