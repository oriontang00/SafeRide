using System.Text.RegularExpressions;
using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

internal class UserRepository : IUserRepository
{
    private IUserSecurityDAO _userSecurityDao;
    public UserRepository(IUserSecurityDAO userSecurityDao)
    {
        userSecurityDao.Create(new UserSecurityModel
        {
            UserName = "apple123",
            Email = "myemail@email.com",
            Role = "admin",
            Valid = true
        });
    }

    public bool CreateUser(UserSecurityModel user)
    {
        if (!Regex.IsMatch(user.UserName, "^[a-zA-Z0-9.,@!]*$"))
        {
            return false;
        }
        return _userSecurityDao.Create(user);
    }

    public bool AuthorizeUser(string otp, string username)
    {
        var user = _userSecurityDao.Read(username);
        /*user.Valid = true
        _userSecurityDao.Update(username, )*/
        return false;
    }

    public UserSecurityModel GetUser(UserSecurityModel user)
    {
        return _userSecurityDao.Read(user.UserName);
    }
}