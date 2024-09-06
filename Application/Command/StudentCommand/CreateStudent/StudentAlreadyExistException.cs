using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.StudentCommand.CreateStudent
{
    public sealed class StudentAlreadyExistException(string email, HttpStatusCode statusCode = HttpStatusCode.BadRequest) 
        : BaseException(string.Format(_messages, email), statusCode)
    {
        private const string _messages = "Student with The `{0}` already exists.";
    }
}
