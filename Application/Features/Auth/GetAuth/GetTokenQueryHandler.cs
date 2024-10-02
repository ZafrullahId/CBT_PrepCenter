using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Shared;
using MediatR;


namespace CBTPreparation.Application.Features.Auth.GetAuth
{
    public class GetTokenQueryHandler(IUserRepository userRepository, IPasswordHasher _passwordHasher, ITokenProvider tokenProvider) : IRequestHandler<GetTokenQuery, GetTokenQueryResponse>
    {
        public async Task<GetTokenQueryResponse> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(x => x.Email == request.Email, cancellationToken);
            if (user is { })
            {
                bool verified = _passwordHasher.Verify(request.Password, user.PasswordHash);

                if (!verified)
                {
                    throw new AuthenticationFailedException(user.Email);
                }
                var (Token, RefreshToken) = tokenProvider.Create(user);
                // log the user
                return new GetTokenQueryResponse(Token, RefreshToken, new BaseResponse("Successfully LoggedIn", false));
            }
            return new GetTokenQueryResponse("", "", new BaseResponse("Invalid Credentials", false));
        }
    }
}
