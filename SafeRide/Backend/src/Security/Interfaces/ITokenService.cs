using SafeRide.src.Models;

public interface ITokenService
{
    public string BuildToken(string key, string issuer, UserSecurityModel user);
}