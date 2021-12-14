using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Security
{
    public class UserSecurity : ISecurity
    {
        public bool Authenticate(Func<object, bool> func, object obj)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(Func<object, bool> func, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
