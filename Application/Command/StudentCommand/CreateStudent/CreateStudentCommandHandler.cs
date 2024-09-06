using Application.Abstraction.Repositiories;
using Application.Command.StudentCommand.CreateStudent;
using Application.Dtos.ResponseModel;
using Domain.Entity;
using Domain.Enum;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.StudentCommand.CreateStudent
{
    public class CreateStudentCommandHandler(IStudentRepository _studentRepository, IUserRepository _userRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetAsync(x => x.Email == request.model.Email, cancellationToken);
            if (userExist is not null)
            {
                throw new StudentAlreadyExistException(userExist.Email);
            }
            var user = User.Create(request.model.FirstName, request.model.LastName, request.model.Email, request.model.Password, Role.Student);

            var student = Student.Create(user);

            await _studentRepository.CreateAsync(student, cancellationToken);
            await _unitOfWorkRepository.SaveChangesAsync();

            return new StudentResponse()
            {
                Message = "Student Successfully Created",
                Success = true
            };

        }
    }
}
