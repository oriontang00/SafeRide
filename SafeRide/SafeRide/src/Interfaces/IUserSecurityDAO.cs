using SafeRide.src.Models;

namespace SafeRide.src.Interfaces;

public interface IUserSecurityDAO
{
    public bool Create(UserSecurityModel user);
    public UserSecurityModel Read(string username);
    public bool Update(string username, UserSecurityModel user);
    public bool Delete(string username);
}