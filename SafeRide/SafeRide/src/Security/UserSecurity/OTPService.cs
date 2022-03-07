using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Security.UserSecurity;

public class OTPService : IOTPService
{
    private IUserSecurityDAO _userSecurityDao;
    private string _userEmail;
    
    public OTPService(IUserSecurityDAO userSecurityDao)
    {
        _userSecurityDao = userSecurityDao;
    }
    
    public string CreateOTP(UserSecurityModel user)
    {
        // generate otp with following reqs:
        // 8 characters long: 
               Random random = new Random();
for (int i = 0; i < 8; i++)
        {

        }
        // A - Z: ASCII 65 - 90 rand.Next(65, 91)
        // a - z: ASCII 97 - 122 rand.Next(97, 123)
        // 0 - 9: ASCII 48 - 57 rand.Next(48, 58)


       
      
        string otp = random.Next(10000000, 99999999);

        return otp;
    }

    public bool ValidateOTP(string password, UserSecurityModel user)
    {
        throw new NotImplementedException();
    }
}