using SafeRide.src.Models;

internal interface ITokenService
{
    public string BuildToken(string key, string issuer, UserSecurityDTO user);
    public bool IsTokenValid(string key, string issuer, string token);
}