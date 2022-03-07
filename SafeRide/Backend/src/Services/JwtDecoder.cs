using System.IdentityModel.Tokens.Jwt;

namespace Backend.Services;

public static class JwtDecoder
{
    public static JwtSecurityToken? DecodeJwt(string token)
    {
        token = token.Replace("Bearer ", "");
        token = token.Replace("\"", "");
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
                
            return jwtSecurityToken;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}