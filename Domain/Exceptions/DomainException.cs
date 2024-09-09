using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
