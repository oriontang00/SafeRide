using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Security.UserSecurity;

public class OTPService : IOTPService
{
    private IUserSecurityDAO _userSecurityDao;
    
    public OTPService(IUserSecurityDAO userSecurityDao)
    {
        _userSecurityDao = userSecurityDao;
    }
    
    public bool CreateOTP(UserSecurityModel user)
    {
        Random random = new Random();
        var otp = random.Next(10000000, 99999999);

        return false;
    }

    public bool ValidateOTP(string password, UserSecurityModel user)
    {
        throw new NotImplementedException();
    }
}