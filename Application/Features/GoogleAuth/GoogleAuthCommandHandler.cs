using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Shared;
using Domain.Entity;
using Domain.Enum;
using Google.Apis.Auth;
using MapsterMapper;
using MediatR;


namespace Application.Features.GoogleAuth
{
    public class GoogleAuthCommandHandler : IRequestHandler<GoogleAuthCommand, GoogleAuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IStudentRepository _studentRepository;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public GoogleAuthCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
           IStudentRepository studentRepository, IGoogleAuthService googleAuthService, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _studentRepository = studentRepository;
            _googleAuthService = googleAuthService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<GoogleAuthResponse> Handle(GoogleAuthCommand request, CancellationToken cancellationToken)
        {
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await _googleAuthService.ValidateAsync(request.IdToken);
            }
            catch (InvalidJwtException ex)
            {
                throw new NotFoundException($"{ex.Message}");
            }
            var dbUser = await _userRepository.GetAsync(u => u.Email == payload.Email, cancellationToken);
            if (dbUser is null)
            {
                var newUser = _mapper.Map<User>(payload);
                var user = User.Create(
                   newUser.FirstName,
                   newUser.LastName,
                   newUser.Email,
                   _passwordHasher.Hash(newUser.PasswordHash),
                   Role.Student);

                var student = Student.Create(user);

                await _studentRepository.CreateAsync(student, cancellationToken);

                var (Token, RefreshToken) = _tokenProvider.Create(user);

                return new GoogleAuthResponse(
                Token,
                RefreshToken,
                new BaseResponse(
                "Student Successfully Login",
                true));
            }

            var (Tokendb, RefreshTokendb) = _tokenProvider.Create(dbUser);

            return new GoogleAuthResponse(
                Tokendb,
                 RefreshTokendb,
                new BaseResponse(
                "Student Successfully Login",
                true));


        }
    }
}
