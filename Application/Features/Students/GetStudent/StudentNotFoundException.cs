using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using CBTPreparation.Domain.StudentAggregate;
using System.Net;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public class StudentNotFoundException(StudentId studentId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : DomainException(string.Format(_messages, studentId.Value), statusCode)
    {
        private const string _messages = "Student `{0}` not found.";
    }
}
