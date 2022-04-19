using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Services
{
    public class ParseResponseService : IParseResponseService
    {
        private string _jsonResponse { get; set; } 
        private DirectionsResponse _directionsResponse { get; set; } 
        public ParseResponseService(string jsonResponse) {
            this._jsonResponse = jsonResponse;
            this._directionsResponse = JsonConvert.DeserializeObject<DirectionsResponse>(_jsonResponse); 
        }

        // helps simplify HazardExclusion by providing only the first route  the response
        public Route ParseFirstRoute() {
            List<Route> routes = JsonConvert.DeserializeObject<Route>(_jsonResponse);
            return routes[0];
        }

        // helps simplify finding the hazard search radii in the initial route by extracting coordinates from whenever the route takes a step in a new direction
        public Dictionary<double, double> ParseStepCoordinates() {
            // initialize dict to store parsed results
            Dictionary<double, double> results = new Dictionary<double, double>();          
            
            // iterate all Steps taken by the initial route
            // assume initial route was requested with no additional waypoints beside starting and ending coordinates, so it has only 1 leg
            Route initialRoute = ParseFirstRoute();
            List<Step> steps = initialRoute._legs[0]._steps;
            // add each extracted coordinate to the turn coordinatees
            for (int i = 0; i < steps.Count; i++) {
                double stepX = steps[i]._maneuver._location[0];
                double stepY = steps[i]._maneuver._location[1];
                results.Add(turnX, turnY);
            }
            return results;
        }
    }
}
