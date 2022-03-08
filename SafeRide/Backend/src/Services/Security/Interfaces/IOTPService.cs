using SafeRide.src.Models;

namespace SafeRide.src.Security.Interfaces;

public interface IOTPService
{
    public void SendEmail();
    public void ValidateOTP(string providedOTP);

}