using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Security
{
    public class UserSecurity : ISecurity
    {
        private User user;

        public UserSecurity(User user)
        {
            this.user = user;
            
            bool isAuthorized = Authorize(UserAuthorize, user);
        }
        private bool UserAuthenticate(String userName, String userID, String password)
        {

            return user != null;
        }

        private bool UserAuthorize(object user)
        {
            return user != null;
        }

        public bool Authenticate(Func<object, bool> func, object obj)
        {
            return func(obj);
        }

        public bool Authorize(Func<object, bool> func, object obj)
        {
            return func(obj);
        }
    }
}
