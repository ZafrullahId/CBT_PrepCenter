using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using Domain;
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
                false,
                Constants.RoleConstant.StudentRoleName,
                _passwordHasher.Hash(request.Password));

            var student = Student.Create(user.Id);

            await _studentRepository.CreateStudentAsync(student, cancellationToken);

            return new CreateStudentCommandResponse(student.Id,
                new BaseResponse(
                "Student Successfully Created",
                true));

        }
    }
}
