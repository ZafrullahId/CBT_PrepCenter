using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.GoogleAuth
{
    public record GoogleAuthRequestEndpoint([FromRoute(Name = "id-token")] string IdToken);
}
