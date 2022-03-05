using SafeRide.src.Models;

internal interface ITokenService
{
    public string BuildToken(string key, string issuer, UserSecurityModel user);
}