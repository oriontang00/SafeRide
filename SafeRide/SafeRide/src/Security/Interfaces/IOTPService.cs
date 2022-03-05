using SafeRide.src.Models;

namespace SafeRide.src.Security.Interfaces;

public interface IOTPService
{
    public bool CreateOTP(UserSecurityModel user);
    public bool ValidateOTP(string password, UserSecurityModel user);

}