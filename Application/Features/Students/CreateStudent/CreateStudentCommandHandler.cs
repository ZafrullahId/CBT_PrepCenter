using Application.Abstractions.Repositories;
using Application.Shared;
using Domain.Entity;
using Domain.Enum;
using MediatR;

namespace Application.Features.Students.CreateStudent
{
    public class CreateStudentCommandHandler(IStudentRepository _studentRepository, IUserRepository _userRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateStudentCommand, CreateStudentCommandResponse>
    {
        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetAsync(x => x.Email == request.Email, cancellationToken);
            if (userExist is not null)
            {
                throw new StudentAlreadyExistException(userExist.Email);
            }
            var user = User.Create(request.FirstName, request.LastName, request.Email, request.Password, Role.Student);

            var student = Student.Create(user);

            await _studentRepository.CreateAsync(student, cancellationToken);
            await _unitOfWorkRepository.SaveChangesAsync(cancellationToken);

            return new CreateStudentCommandResponse(
                student.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                new BaseResponse(
                "Student Successfully Created",
                true));

        }
    }
}
