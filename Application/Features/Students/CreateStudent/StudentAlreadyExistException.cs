using Application.Exceptions;
using System.Net;

namespace Application.Features.Students.Command
{
    public sealed class StudentAlreadyExistException(string email, HttpStatusCode statusCode = HttpStatusCode.BadRequest) 
        : BaseException(string.Format(_messages, email), statusCode)
    {
        private const string _messages = "Student with The `{0}` already exists.";
    }
}
