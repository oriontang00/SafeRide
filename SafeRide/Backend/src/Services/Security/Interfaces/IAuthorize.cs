namespace SafeRide.src.Security.Interfaces
{
    public interface IAuthorize
    {
        bool Authorize(Func<Object, bool> func, Object obj);
    }
}
