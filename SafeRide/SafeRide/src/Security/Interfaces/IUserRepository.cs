using SafeRide.src.Models;

internal interface IUserRepository
{
    UserSecurityDTO GetUser(UserSecurityModel user);
}