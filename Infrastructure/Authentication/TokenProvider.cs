using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Infrastructure.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Application.Abstractions;

namespace Infrastructure.Authentication;

internal sealed class TokenProvider(IOptions<JwtSettings> jwtSettings) : ITokenProvider
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public (string Token, string RefreshToken) Create(User user)
    {
        string secretKey = _jwtSettings.Key!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            ]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            SigningCredentials = credentials,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        var refreshTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays),
            SigningCredentials = credentials,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        var handler = new JsonWebTokenHandler();

        string token = handler.CreateToken(tokenDescriptor);
        string refreshToken = handler.CreateToken(refreshTokenDescriptor);

        return (token, refreshToken);
    }
}
