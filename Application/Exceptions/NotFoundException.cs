using System.Net;

namespace Application.Exceptions
{
    public class NotFoundException(string Id, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : BaseException(string.Format(_messages, Id), statusCode)
    {
        private const string _messages = "Id `{0}` not found.";
    }
}
