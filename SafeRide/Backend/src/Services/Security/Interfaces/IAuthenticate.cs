namespace SafeRide.src.Security.Interfaces
{
    public interface IAuthenticate
    {
        bool Authenticate(Func<Object, bool> func, Object obj);
    }
}
