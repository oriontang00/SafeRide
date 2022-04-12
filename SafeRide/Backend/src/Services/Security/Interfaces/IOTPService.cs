using SafeRide.src.Models;

namespace SafeRide.src.Security.Interfaces;

public interface IOTPService
{
    public void SendEmail();
    public bool ValidateOTP(string providedOTP);
    //public void SetUser(UserSecurityModel user);
}