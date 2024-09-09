using Application.Exceptions;
using System.Net;

namespace Application.Features.Students.Command
{
    public sealed class StudentAlreadyExistException : BaseException
    {
        private const string _messages = "Student with The `{3}` already exists.";
        public StudentAlreadyExistException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, statusCode)
        {

        }
    }
}
