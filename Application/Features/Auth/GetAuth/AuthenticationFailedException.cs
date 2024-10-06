using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using System.Net;

namespace CBTPreparation.Application.Features.Auth.GetAuth
{
    public sealed class AuthenticationFailedException : DomainException
    {
        private const string _messages = "`{0}` Authentication Failed";

        public AuthenticationFailedException(string email, HttpStatusCode statusCode = HttpStatusCode.Unauthorized) : base(string.Format(_messages, email), statusCode)
        {
            
        }
    }
}
