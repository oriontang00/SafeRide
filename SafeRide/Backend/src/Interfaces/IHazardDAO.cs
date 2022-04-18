using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IUserDAO
    {
        public Dictionary<double, double> GetByHazardInRadius(HazardType type, double radius);

        public bool Report(UserModel user, HazardType type, Coordinate location);
    }
}