using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IHazardExclusionService
    {
        public Dictionary<double, double> FindHazardsNearRoute();
        public Dictionary<double, double> FindSearchTargets();
        public Dictionary<double, double> RadialSearch();
    }
}
