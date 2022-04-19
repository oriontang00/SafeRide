using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Services
{
    public class HazardExclusionService : IHazardExclusionService
    {
        private IHazardDAO _hazardDAO;
        private Route _route;
        private List<Int> _hazards;
        private Dictionary<double, double> _routeCoordinates;
        private Dictionary<double, double>  _searchCoordinates; 
        private Dictionary<double, double>  _hazardCoordinates;
        private int searchCount;
        private const double RADIUS_METERS = 80467.12;

        // initialize a HazardExclusionService by passing in a Route object its step coordinates along with the list of hazards that should be excluded from it
        public HazardExclusionService(Route route, Dictionary<double, double>  routeCoordinates, List<Int> hazards) {
            this._hazardDAO = new HazardDAO();
            this._route = route;
            this._routeCoordinates = routeCoordinates;
            this._searchCoordinates = FindSearchCoordinates();
            this._distance = route._distance;
            this._hazards = hazards;
            _searchCount = 0;
        }
        
        // performs RadialSearches of every excluded hazard types around each searchCoordinate on the route 
        public Dictionary<double, double> FindHazardsNearRoute() {
            // solution dict to store results
            Dictionary<double, double> results = new Dictionary<double, double>();
            
            // go to each searchCoordinate first
            for (int i = 0; i < _hazardCoordinates.Count; i++) {
                // then do a RadialSearch for every type of excluded hazard around the searchCoordinate
                for (int j = 0; j < _hazards.Count; j++) {
                    results.add(RadialSearch(_searchCoordinates[i], _hazards[j]));
                }
            }
            return(results);
        }

        public Dictionary<double, double> FindSearchCoordinates() {
            
            for (int i = 0; i < _route._legs._steps.Count; i++) {
                // get the x and y coordinates of the starting location of each step
                double startX = _route.legs.steps[i].maneuver.location[0];
                double startY = _route.legs.steps[i].maneuver.location[1];
                
                // get the x and y coordinates of the last location in each step
                double endX = _route.legs.steps[steps.Count - 1].maneuver.location[0];
                double endY = _route.legs.steps[steps.Count - 1].maneuver.location[1];
                
                double stepDistance = _route.legs.steps[i].distance;
                Dictionary<double, double> results = new Dictionary<double, double>(); // return variable

                // automatically add first coordinate in the route to search coordinates 
                if (i = 0) {
                    results.Add(startX, startY);
                    _searchCount += 1;
                }
                
                // for the rest of the coordinates, check if still within the previouse radius
                else {
                    if ((startX, startY).IsInside(results[_searchCount - 1],RADIUS_SIZE) == False) {
                        // if not covered by previous radius, create a new one at that coord
                        results.Add(startX, startY);
                        _searchCount += 1;
                    }
                    else {
                        // if the step distance is greater than the search radius, then we need to calculate the number of additional radii needed to span the rest of the leg
                        if (stepDistance > SEARCH_RADIUS) {
                            int reqSearches = (stepDistance + RADIUS_METERS - 1) / RADIUS_METERS; // round up to prevent search gaps
                            
                            // loop through the number of additional searches needed
                            for (int j = 0; j < reqSearches; j++) {
                                
                                // for each one, find a coordinate on the step that is a distance of RADIUS_METERS from the last coordinate searched
                                // formula taken from "https://stackoverflow.com/questions/53404008/how-to-calculate-coordinate-x-meters-away-from-a-point-but-towards-another-in-c"
                                double ratio = RADIUS_METERS / stepDistance;
                                double prevX = results.ElementAt(_searchCount - j + 1).Key;
                                double prevY = results.ElementAt(_searchCount - j + 1).Value;                                
                                double diffX = endX - prevX; 
                                double diffY = endY - prevY;
                                double nextX = lastX + (ratio * diffX);
                                double nextY = lastY + (ratio * diffY);

                                // add the calculated values as the next search in searchCoordinates
                                results.Add(nextX, nextY);
                                _searchCount += 1;
                            }
                        }
                    }
                }
            }
            return results;
        }


        public Dictionary<double, double> RadialSearch(List<double, double> coordinates, HazardType type) {
            double targetX = coordinates.ElementAt[i].Key;
            double targetY = coordinates.ElementAt[i].Value;
            
            return _hazardDAO.
            GetByTypeInRadius(type, targetX, targetY, RADIUS_METERS)    
        }
    }        
}

