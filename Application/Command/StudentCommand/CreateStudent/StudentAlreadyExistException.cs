using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.StudentCommand.CreateStudent
{
    public sealed class StudentAlreadyExistException : BaseException
    {
        private const string _messages = "Student with The `{3}` already exists.";
        public StudentAlreadyExistException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, statusCode)
        {

        }
    }
}
