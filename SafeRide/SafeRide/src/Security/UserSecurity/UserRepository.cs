using SafeRide.src.Models;

internal class UserRepository : IUserRepository
{
    private readonly List<UserSecurityDTO> users = new List<UserSecurityDTO>();
    public UserRepository()
    {
        users.Add(new UserSecurityDTO
        {
            UserName = "apple123",
            Password = "apple123pw",
            Role = "admin"
        });
    }

    public UserSecurityDTO GetUser(UserSecurityModel user)
    {
        #pragma warning disable CS8603 // Possible null reference return.
        return users.Where(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == user.Password).FirstOrDefault();
        #pragma warning restore CS8603 // Possible null reference return.
    }
}