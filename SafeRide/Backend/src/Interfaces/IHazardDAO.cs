using SafeRide.src.Models;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IHazardDAO
    {
        public Dictionary<double, double> FindHazardInRadius(HazardType type, double searchX, double searchY, double radius);

        public int Report(Hazard hazard);
    }
}