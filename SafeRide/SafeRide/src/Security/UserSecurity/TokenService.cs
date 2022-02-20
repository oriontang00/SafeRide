using Microsoft.IdentityModel.Tokens;
using SafeRide.src.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

internal class TokenService : ITokenService
{
    private const double EXPIRY_DURATION_MINUTES = 3000;

    public string BuildToken(string key, string issuer, UserSecurityDTO user)
    {
        var claims = new[] {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.NameIdentifier,
            Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}