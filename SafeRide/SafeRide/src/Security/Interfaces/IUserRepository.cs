using SafeRide.src.Interfaces;
using SafeRide.src.Models;

internal interface IUserRepository
{
    UserSecurityModel GetUser(UserSecurityModel user);
}