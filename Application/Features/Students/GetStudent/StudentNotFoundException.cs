using Application.Exceptions;
using Domain.Entity;
using Domain.Exceptions;
using System.Net;

namespace Application.Features.Students.GetStudent
{
    public class StudentNotFoundException(Guid studentId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : BaseException(string.Format(_messages, studentId), statusCode)
    {
        private const string _messages = "Student `{0}` not found.";
    }
}
