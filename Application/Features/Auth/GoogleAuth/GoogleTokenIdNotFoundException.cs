using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using System.Net;

namespace CBTPreparation.Application.Features.Auth.GoogleAuth
{
    internal class GoogleTokenIdNotFoundException(string TokenId, HttpStatusCode statusCode = HttpStatusCode.NotFound)
        : DomainException(string.Format(_messages, TokenId), statusCode)
    {
        private const string _messages = "Google TokenId `{0}` not found.";
    }
}
