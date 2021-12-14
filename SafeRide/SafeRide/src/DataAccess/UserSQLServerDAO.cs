using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.DataAccess
{
    public class UserSQLServerDAO : IUserDAO
    {
        private User User;
        private String UserId;

        public UserSQLServerDAO()
        {
            this.User = new User();
            this.UserId = "";
        }
        public UserSQLServerDAO(User User, String UserId)
        {
            this.User = User;
            this.UserId = UserId;
        }

        public bool Create(User User)
        {
            return false;
        }

        public User Read(String UserId)
        {
            return new User();
        }

        public bool Update(String UserId, User User)
        {
            return false;
        }

        public bool Delete(String UserId)
        {
            return false;
        }

        public bool Enable(String UserId)
        {
            return false;
        }

        public bool Disable(String UserId) 
        { 
            return false; 
        }
    }
}
