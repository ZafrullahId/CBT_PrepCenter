using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Middlewares
{
    public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetailFromException(exception);
            problemDetails.Instance = httpContext.Request.Path;

            logger.LogError("{ProblemDetailsTitle}", problemDetails.Detail);
            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }

        private static ProblemDetails CreateProblemDetailFromException(Exception exception)
        {
            return exception is DomainException e
                ? new ProblemDetails
                {
                    Status = (int)e.StatusCode,
                    Title = "Bad Request",
                    Detail = e.Message,
                }
                : new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server error",
                    Detail = exception.Message,

                };
        }
    }
}
