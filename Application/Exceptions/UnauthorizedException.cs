

using Application.Exceptions;
using System.Net;

namespace Infrastructure.Jwt.Exceptions
{
    public class UnauthorizedException(string message) : BaseException(message, HttpStatusCode.Unauthorized)
    {
    }
}
