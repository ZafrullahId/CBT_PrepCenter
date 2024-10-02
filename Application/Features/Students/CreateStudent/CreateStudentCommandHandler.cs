using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using Domain.Enum;
using MediatR;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public class CreateStudentCommandHandler(IStudentRepository _studentRepository, IUserRepository _userRepository, IPasswordHasher _passwordHasher) : IRequestHandler<CreateStudentCommand, CreateStudentCommandResponse>
    {
        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetAsync(x => x.Email == request.Email, cancellationToken);
            if (userExist is not null)
            {
                throw new StudentAlreadyExistException(userExist.Email);
            }
            var user = User.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                _passwordHasher.Hash(request.Password),
                Role.Student);

            var student = Student.Create(user);

            await _studentRepository.CreateAsync(student, cancellationToken);

            return new CreateStudentCommandResponse(
                student.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PasswordHash,
                new BaseResponse(
                "Student Successfully Created",
                true));

        }
    }
}
