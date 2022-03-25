using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IUserDAO
    {
        public bool Create(UserModel User);
        public UserModel Read(String UserId);
        public bool Update(String UserId, UserModel User);
        public bool Delete(String UserId);
        public bool Enable(String UserId);
        public bool Disable(String UserId);
        public Dictionary<String, int> GetLastThreeMonthLogins();
        public Dictionary<String, int> GetLastThreeMonthRegistrations();
        public int UpdateLastLogin(String UserId, DateTime dateTime);

    }
}
