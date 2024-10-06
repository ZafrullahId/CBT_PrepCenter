using Google.Apis.Auth;

namespace CBTPreparation.Application.Abstractions
{
    public interface IGoogleAuthService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken);
    }
}
