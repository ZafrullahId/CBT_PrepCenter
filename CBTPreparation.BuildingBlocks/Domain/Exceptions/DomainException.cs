using System.Net;

namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
