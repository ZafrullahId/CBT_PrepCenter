using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPreparation.Application.Features.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler(IStudentRepository _studentRepository, IUserRepository _userRepository) : IRequestHandler<UpdateStudentCommand, UpdateStudentCommandResponse>
    {
        public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentAsync(request.StudentId, cancellationToken);

            if (student is { })
            {
                var user = await _userRepository.GetUserAsync(student.UserId, cancellationToken);
                if (user is { })
                {
                    user.Update(request.FirstName, request.LastName);
                    student.Update(request.Department, request.Courses);
                    return new UpdateStudentCommandResponse(new BaseResponse("Student Successfully Updated", true));
                }
            }
            throw new StudentNotFoundException(student.Id);
        }
    }
}
