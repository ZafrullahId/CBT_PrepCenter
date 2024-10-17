using CBTPreparation.Domain.UserAggregate;
using System.Security.Claims;

namespace CBTPreparation.Application.Abstractions
{
    public interface ITokenProvider
    {
        string CreateRefresh(IEnumerable<Claim> claims);
        (string Token, string RefreshToken) Create(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}