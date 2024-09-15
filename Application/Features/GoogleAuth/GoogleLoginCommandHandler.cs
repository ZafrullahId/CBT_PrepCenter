﻿using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Shared;
using Domain.Entity;
using Domain.Enum;
using Google.Apis.Auth;
using MapsterMapper;
using MediatR;


namespace Application.Features.GoogleAuth
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IStudentRepository _studentRepository;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public GoogleLoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
           IStudentRepository studentRepository, IGoogleAuthService googleAuthService, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _studentRepository = studentRepository;
            _googleAuthService = googleAuthService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await _googleAuthService.ValidateAsync(request.IdToken);
            }
            catch (InvalidJwtException ex)
            {
                return new GoogleLoginResponse(ex.Message, "", new BaseResponse("Invalid Google token.", false));
            }
            var dbUser = await _userRepository.GetAsync(u => u.Email == payload.Email, cancellationToken);
            if (dbUser == null)
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

                return new GoogleLoginResponse(
                Token,
                RefreshToken,
                new BaseResponse(
                "Student Successfully Login",
                true));
            }

            var (Tokendb, RefreshTokendb) = _tokenProvider.Create(dbUser);

            return new GoogleLoginResponse(
                Tokendb,
                 RefreshTokendb,
                new BaseResponse(
                "Student Successfully Login",
                true));


        }
    }
}
