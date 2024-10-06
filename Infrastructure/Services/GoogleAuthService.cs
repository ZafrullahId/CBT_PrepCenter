using CBTPreparation.Application.Abstractions;
using Google.Apis.Auth;

namespace CBTPreparation.Infrastructure.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        public Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken)
        {
            return GoogleJsonWebSignature.ValidateAsync(idToken);
        }
    }
}
