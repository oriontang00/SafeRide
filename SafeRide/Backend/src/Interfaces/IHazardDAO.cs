using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IHazardDAO
    {
        public Dictionary<double, double> GetByTypeInRadius(int hazardType, double targetX, double targetY, double radius);

        public int Report(Hazard hazard);
    }
}