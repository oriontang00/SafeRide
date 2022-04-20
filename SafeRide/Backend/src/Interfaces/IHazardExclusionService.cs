using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IHazardExclusionService
    {
        public Dictionary<double, double> FindHazardsNearRoute(List<int> hazards);

        public Dictionary<double, double> FindSearchCoordinates();
        bool IsInside(double centerX, double centerY, double targetX, double targetY, double radius);

    }
}
