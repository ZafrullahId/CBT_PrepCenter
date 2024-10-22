using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using Domain;
using Google.Apis.Auth;
using MediatR;


namespace CBTPreparation.Application.Features.Auth.GoogleAuth
{
    public class GoogleAuthCommandHandler : IRequestHandler<GoogleAuthCommand, GoogleAuthCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IStudentRepository _studentRepository;
        private readonly IGoogleAuthService _googleAuthService;

        public GoogleAuthCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
           IStudentRepository studentRepository, IGoogleAuthService googleAuthService)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _studentRepository = studentRepository;
            _googleAuthService = googleAuthService;
        }

        public async Task<GoogleAuthCommandResponse> Handle(GoogleAuthCommand request, CancellationToken cancellationToken)
        {
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await _googleAuthService.ValidateAsync(request.IdToken);
            }
            catch (InvalidJwtException ex)
            {
                throw new GoogleTokenIdNotFoundException($"{ex.Message}");
            }

            var dbUser = await _userRepository.GetUserAsync(u => u.Email == payload.Email, cancellationToken);

            if (dbUser is null)
            {
                var user = User.Create(
                   payload.GivenName,
                   payload.FamilyName,
                   payload.Email,
                   true,
                   Constants.RoleConstant.StudentRoleName);

                var student = Student.Create(user.Id);

                await _studentRepository.CreateStudentAsync(student, cancellationToken);

                var (NewUserToken, NewUserRefreshToken) = _tokenProvider.Create(user);

                return new GoogleAuthCommandResponse(
                                NewUserToken,
                                NewUserRefreshToken,
                                new BaseResponse(
                                "Student Successfully Login",
                                true));
            }

            var (Token, RefreshToken) = _tokenProvider.Create(dbUser);

            return new GoogleAuthCommandResponse(
                            Token,
                            RefreshToken,
                            new BaseResponse(
                            "Student Successfully Login",
                            true));


        }
    }
}
