using Microsoft.Extensions.Configuration;

namespace CBTPreparation.Application.Handlers
{
    public class AuthenticationDelegatingHandler(IConfiguration configuration)
    : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("AccessToken", configuration["Aloc:AccessToken"]);

            return base.SendAsync(request, cancellationToken);
        }
    }
}  
