using Application.Abstraction.Repositiories.IRepository;
using Application.Command.StudentCommand.CreateStudent;
using Application.Dtos.ResponseModel;
using Domain.Entity;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.StudentCommand.CreateStudent
{
    public class CreateStudentCommandHandler(IStudentRepository _studentRepository,IUserRepository _userRepository) : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetAsync(x => x.Email == request.Model.Email,cancellationToken);
            if(userExist is null) 
            {
                /*return new StudentResponse { Message = "Email Already IN  Use" };*/ 
                throw new StudentAlreadyExistException(userExist.Email);
            }
            await _userRepository.CreateAsync(request.Adapt<User>(),cancellationToken);
            await _studentRepository.CreateAsync(request.Adapt<Student>(),cancellationToken);
            return new StudentResponse()
            {
                Message =  "Student Successfully Created",
                Success = true
            };
            
        }
    }
}
