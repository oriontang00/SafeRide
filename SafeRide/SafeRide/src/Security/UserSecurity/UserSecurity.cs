using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Security
{
    public class UserSecurity : ISecurity
    {
        private User user;
        private bool isAuthenticated;
        private bool isAuthorized;
        private Dictionary<string, DateTime> userAttemptTime;
        private Dictionary<string, int> userAttempCount;
        private Dictionary<string, DateTime> lockedUsers;
        private char[] VALID_CHARS = @"abcdefghijklmnopqrstuvwxyz0123456789.,@!".ToCharArray();

        public bool IsAuthenticated{ get { return isAuthenticated; } set { } }
        public bool IsAuthorized { get { return isAuthorized; } set { } }

        public UserSecurity(User user)
        {
            this.user = user;
            this.userAttemptTime = new Dictionary<string, DateTime>();
            this.userAttempCount = new Dictionary<string, int>();
            this.lockedUsers = new Dictionary<string, DateTime>();
            isAuthenticated = Authenticate(UserAuthenticate, user);
            isAuthorized = Authorize(UserAuthorize, user);
        }
        private bool UserAuthenticate(object user)
        {
            User myUser = (User)user;
            bool attempSuccess = true;
            string userName = myUser.UserName;

            userAttempCount[userName] = 1;

            foreach (char c in userName)
            {
                if (!VALID_CHARS.Contains(c)) // 
                {
                    attempSuccess = false;
                    userAttempCount[userName] = userAttempCount[userName] + 1;
                    userAttemptTime.Add(userName, DateTime.Now);
                    break;
                }
            }

            if (userAttempCount[userName] > 5 && DateTime.Now < userAttemptTime[userName].AddDays(1))
            {
                
            }

            return attempSuccess;
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
