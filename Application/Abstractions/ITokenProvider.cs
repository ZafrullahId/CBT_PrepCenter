using CBTPreparation.Domain.UserAggregate;
using System.Security.Claims;

namespace CBTPreparation.Application.Abstractions
{
    public interface ITokenProvider
    {
        string GenerateRefreshToken();
        string Create(IEnumerable<Claim> claims);
        (string Token, string RefreshToken) Create(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}