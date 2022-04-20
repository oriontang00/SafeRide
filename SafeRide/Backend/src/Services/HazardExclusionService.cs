using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Services
{
    public class HazardExclusionService : IHazardExclusionService
    {
//        private IViewEventDAO _viewEventDAO;
        private IHazardDAO _hazardDAO;
        private MapRoute _route;
        private double _distance;
        private Dictionary<double, double>  _searchCoordinates; 
        private int _searchCount;
        private const double RADIUS_METERS = 80467.12;

        // initialize a HazardExclusionService by passing in a Route object its step coordinates along with the list of hazards that should be excluded from it
        public HazardExclusionService(MapRoute route) {
            this._hazardDAO = new HazardDAO();
            this._route = route;
            this._distance = route.Distance;
            this._searchCount = 0;
        }

        // performs RadialSearches of every excluded hazard types around each searchCoordinate on the route 
        public Dictionary<double, double> FindHazardsNearRoute(List<int> hazards)
        {
            // solution dict to store results
            Dictionary<double, double> results = new Dictionary<double, double>();


            this._searchCoordinates = FindSearchCoordinates();


            // go to each searchCoordinate first
            for (int i = 0; i < _searchCoordinates.Count; i++)
            {
                // then do a RadialSearch for every type of excluded hazard around the searchCoordinate
                for (int j = 0; j < hazards.Count; j++)
                {

                    double targetX = _searchCoordinates.ElementAt(i).Key;
                    double targetY = _searchCoordinates.ElementAt(i).Key;
                    Dictionary<double, double> foundCoordinates = _hazardDAO.
        GetByTypeInRadius(hazards[j], targetX, targetY, RADIUS_METERS);
                    // append the results dict with the dict of queried coordinates
                    results.ToList().ForEach(pair => foundCoordinates[pair.Key] = pair.Value);
                }
            }
        return results;
        }
        

        public Dictionary<double, double> FindSearchCoordinates() {
            Dictionary<double, double> results = new Dictionary<double, double>(); // return variable
            
            List<Step> routeSteps = _route.Legs[0].Steps;// extract the list of steps taken by the route



           // at each step location, use the search radius to find all the  coordinates between itself and the next step that must be searched in order to cover the entire step
            for (int i = 0; i < routeSteps.Count + 1;  i++) {
                // get the distance and x and y coordinates of the current step
                double stepDistance = routeSteps[i].Distance;     
                double startX = routeSteps[i].Maneuver.Location[0];
                double startY = routeSteps[i].Maneuver.Location[1];
                // get the x and y coordinates of the next step
                double endX = routeSteps[i+1].Maneuver.Location[0];
                double endY = routeSteps[i+1].Maneuver.Location[1];

                // automatically add the first and last steps as search coordinates
                if (i == 0 || i == routeSteps.Count)
                {
                    results.Add(startX, startY);
                    _searchCount += 1;
                }
                // for each step in between them, check if it is still covered by the radius of the last search coodrinate 
                else
                {
                    if (IsInside(startX, startY, results.ElementAt(_searchCount - 1).Key, results.ElementAt(_searchCount - 1).Value, RADIUS_METERS) == false)
                    {
                        // if not covered by previous radius, create a new one at that coord
                        results.Add(startX, startY);
                        _searchCount += 1;
                    }
                    else
                    {
                        // if the step distance is greater than the search radius, then we need to calculate the number of additional radii needed to span the rest of the leg
                        if (stepDistance > RADIUS_METERS)
                        {
                            int reqSearches = (int) Math.Ceiling((stepDistance + RADIUS_METERS - 1) / RADIUS_METERS); // round up to prevent search gaps

                            // loop through the number of additional searches needed
                            for (int j = 0; j < reqSearches; j++)
                            {
                                /* to find the location of the next search, find a coordinate that is a distance of RADIUS_METERS from the last coordinate searched in the direction of the last coordinate on the step (i.e., the coordinate where the next step starts  
                                 * formula taken from "https://stackoverflow.com/questions/53404008/how-to-calculate-coordinate-x-meters-away-from-a-point-but-towards-another-in-c" */

                                double ratio = RADIUS_METERS / stepDistance;
                                double prevX = results.ElementAt(_searchCount - j + 1).Key;
                                double prevY = results.ElementAt(_searchCount - j + 1).Value;
                                double diffX = endX - prevX;
                                double diffY = endY - prevY;
                                double nextX = prevX + (ratio * diffX);
                                double nextY = prevY + (ratio * diffY);

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

        // given a center coordinate, radius, and target coordinate,  checks if the target is inside the radius around the center
        public bool IsInside(double centerX, double centerY, double targetX, double targetY, double radius)
        {  
            double distanceBetween = Math.Sqrt((Math.Pow(centerX - targetX, 2) + Math.Pow(centerY - targetY, 2)));
            return (distanceBetween <= radius);
        }
    }        
}

