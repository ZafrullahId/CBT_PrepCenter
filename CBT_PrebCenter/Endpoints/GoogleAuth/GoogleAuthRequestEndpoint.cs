using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.GoogleAuth
{
    public record GoogleAuthRequestEndpoint([FromRoute(Name = "id-token")] string IdToken);
}
