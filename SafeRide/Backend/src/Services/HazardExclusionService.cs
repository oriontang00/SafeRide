using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Services
{
    public class HazardExclusionService : IHazardExclusionService
    {
        private Route _route;
        private List<HazardType> _hazards;
        private Dictionary<double, double> _routeCoordinates;
        private Dictionary<double, double> _hazardCoordinates;
        private Dictionary<double, double> _searchCoordinates; 
        private int searchCount;
        private const double RADIUS_METERS = 80467.12;
        
        public Dictionary<double, double> FindHazardsNearRoute();
        public Dictionary<double, double> FindSearchTargets();
        public Dictionary<double, double> RadialSearch();
    }
}
