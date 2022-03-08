using SafeRide.src.Interfaces;
using SafeRide.src.Models;

public interface IUserRepository
{
    UserSecurityModel GetUser(UserSecurityModel user);
}