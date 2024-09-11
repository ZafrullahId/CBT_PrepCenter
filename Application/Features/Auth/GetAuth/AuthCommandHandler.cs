using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Application.Features.Auth.GetAuth
{
    public class AuthCommandHandler(IUserRepository userRepository, IPasswordHasher _passwordHasher, ITokenProvider tokenProvider) : IRequestHandler<AuthCommand, AuthCommandResponse>
    {
        public async Task<AuthCommandResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(x => x.Email == request.Email && x.PasswordHash == request.Password, cancellationToken);
            if (user is { })
            {
                bool verified = _passwordHasher.Verify(request.Password, user.PasswordHash);

                if (!verified)
                {
                    return new AuthCommandResponse("", "", new BaseResponse("Invalid Credentials", false));

                }
                var (Token, RefreshToken) = tokenProvider.Create(user);
                return new AuthCommandResponse(Token, RefreshToken, new BaseResponse("Successfully LoggedIn", false));
            }
            return new AuthCommandResponse("", "", new BaseResponse("Invalid Credentials", false));
        }
    }
}
