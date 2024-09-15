using Google.Apis.Auth;

namespace Application.Abstractions
{
    public interface IGoogleAuthService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken);
    }
}
