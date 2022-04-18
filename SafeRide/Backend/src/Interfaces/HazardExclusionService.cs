using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Services
{
    public class HazardExclusionService : IHazardExclusionService
    {
        private IHazardDAO _hazardDAO;
        private Route _route;
        private List<HazardType> _hazards;
        private Dictionary<double, double> _routeCoordinates;
        private Dictionary<double, double> _hazardCoordinates;
        private Dictionary<double, double> _searchCoordinates; 
        private int searchCount;
        private const double RADIUS_METERS = 80467.12;

        public HazardExclusionService(Route route) {
            this._hazardDAO = new HazardDAO();
            // the route arg is a JSON object passed in from the MapBox Directions API response on the frontend, it must first be converted to a JSON string so that its data can be extracted and processed
            this._route = new JavaScriptSerializer().Serialize(route);
            // the original Route object uses a "geometry" parameter to store a list of all of the locations routed through in its "coordinates" field 
            // iterate through each location stored in "coordinates" and add them to _routeCoordinates
            for (int i = 0; i < _route.geometry().coordinates().Count; i++) {
                double currentLat = _route.geometry().coordinates().get(i)[0];
                double currentLong= _route.geometry().coordinates().get(i)[1];
                this._routeCoordinates.Add(currentLat, currentLong);
            }

            this.Distance = route.distance();
            _searchCount = 0;
        }
        
        public Dictionary<double, double> FindHazardsNearRoute(List<HazardType> hazards) {
            this._hazards = hazards;
            this._searchCoordinates = FindSearchCoordinates();
            for (int i = 0; i < _hazards.Count; i++) {
                this._hazardCoordinates.add(RadialSearch(coordinates, _hazards[i]));
            }
            return(_hazardCoordinates);
        }

        public Dictionary<double, double> FindSearchCoordinates() {
            for (int i = 0; i < _route.legs().steps().Count; i++) {
                // get the x and y coordinates of the starting location of each step
                double startX = _route.legs().steps().get(i).geometry().coordinates().get(0).get(0);
                double startY = _route.legs().steps().get(i).geometry().coordinates().get(0).get(1);
                
                // get the x and y coordinates of the last location in each step
                double endX = _route.legs().steps().get(i).geometry().coordinates().get(coordinates().Count - 1).get(0);
                double endX = _route.legs().steps().get(i).geometry().coordinates().get(coordinates().Count - 1).get(1);

                double stepDistance = _route.legs().steps().get(i).distnace();
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
                        results.Add(startY, startX);
                        _searchCount += 1;
                    }
                    else {
                        // if the leg distance is greater than the search radius, then we need to calculate the number of additional radii needed to cover the rest of the leg
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
        public Dictionary<double, double> RadialSearch(Dictionary<double, double> coordinates, HazardType type) {
            for (int i = 0; i < coordinates.Count; i++) {
                double targetX = coordinates.ElementAt[i].Key;
                double targetY = coordinates.ElementAt[i].Value;
                Dictionary<double, double> foundHazards = _hazardDAO.FindHazardInRadius(type, targetX, targetY, RADIUS_METERS);
                _hazardCoordinates.Add(foundHazards);
            }
        }        
    }
}
