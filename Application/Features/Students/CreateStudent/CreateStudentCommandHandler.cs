using Application.Abstraction.Repositories;
using Application.Features.Students.CreateStudent;
using Application.Features.Students.Dtos.Response;
using Domain.Entity;
using Domain.Enum;
using MediatR;

namespace Application.Features.Students.CreateStudent
{
    public class CreateStudentCommandHandler(IStudentRepository _studentRepository, IUserRepository _userRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetAsync(x => x.Email == request.Model.Email, cancellationToken);
            if (userExist is not null)
            {
                throw new StudentAlreadyExistException(userExist.Email);
            }
            var user = User.Create(request.Model.FirstName, request.Model.LastName, request.Model.Email, request.Model.Password, Role.Student);

            var student = Student.Create(user);

            await _studentRepository.CreateAsync(student, cancellationToken);
            await _unitOfWorkRepository.SaveChangesAsync(cancellationToken);

            return new StudentResponse()
            {
                Message = "Student Successfully Created",
                Success = true
            };

        }
    }
}
