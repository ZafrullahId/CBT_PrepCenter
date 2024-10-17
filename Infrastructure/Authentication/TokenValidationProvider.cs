using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CBTPreparation.Infrastructure.Authentication
{
    internal class TokenValidationProvider
    {
        public async Task<(bool IsValid, ClaimsPrincipal UserClaims)> ValidateRefreshTokenAsync(string refreshToken, TokenValidationParameters validationParameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            try
            {
                // Validate the token
                var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                // Additional checks (e.g., token expiration)
                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (false, null); // Invalid token
                }

                // Check token expiration
                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    return (false, null); // Token has expired
                }

                return (true, principal); // Valid token
            }
            catch
            {
                // Token validation failed
                return (false, null);
            }
        }
    }
}
