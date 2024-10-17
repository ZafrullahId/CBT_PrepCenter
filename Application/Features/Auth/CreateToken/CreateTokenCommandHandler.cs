using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.UserAggregate;
using MediatR;


namespace CBTPreparation.Application.Features.Auth.CreateToken
{
    public class CreateTokenCommandHandler(IUserRepository userRepository, IPasswordHasher _passwordHasher, ITokenProvider tokenProvider) : IRequestHandler<CreateTokenCommand, CreateTokenCommandResponse>
    {
        public async Task<CreateTokenCommandResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserAsync(x => x.Email == request.Email, cancellationToken);

            if (user is { })
            {
                if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                {
                    bool verified = _passwordHasher.Verify(request.Password, user.PasswordHash);

                    if (!verified)
                    {
                        throw new AuthenticationFailedException(user.Email);
                    }
                    var (Token, RefreshToken) = tokenProvider.Create(user);
                    // log the user
                    return new CreateTokenCommandResponse(new BaseResponse("Successfully LoggedIn", false), Token, RefreshToken);
                }
            }
            return new CreateTokenCommandResponse(new BaseResponse("Invalid Credentials", false));
        }
    }
}
