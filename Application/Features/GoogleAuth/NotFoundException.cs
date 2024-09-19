using Domain.Exceptions;
using System.Net;

namespace Application.Features.GoogleAuth
{
    internal class NotFoundException(string TokenId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : DomainException(string.Format(_messages, TokenId), statusCode)
    {
        private const string _messages = "TokenId `{0}` not found.";
    }
}
