using CBTPreparation.Domain.StudentAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPreparation.Application.Features.Students.UpdateStudent
{
    public record UpdateStudentCommand(StudentId StudentId, string FirstName, string LastName, string Department, List<Course> Courses) : IRequest<UpdateStudentCommandResponse>;
}
