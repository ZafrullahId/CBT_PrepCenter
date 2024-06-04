namespace Infrastructure.Jwt.Exceptions
{
    public class ForbiddenExceptionHandler(string message) : Exception(message)
    {

    }
}
