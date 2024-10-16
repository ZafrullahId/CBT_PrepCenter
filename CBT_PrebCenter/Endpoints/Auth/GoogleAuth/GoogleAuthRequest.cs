using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Auth.GoogleAuth
{
    public record GoogleAuthRequest([FromRoute(Name = "token-id")] string TokenId);
}
