using Application.Exceptions;
using System.Net;

namespace Infrastructure.Jwt.Exceptions
{
    public class ForbiddenException(string message) : BaseException(message, HttpStatusCode.Forbidden)
    {

    }
}
