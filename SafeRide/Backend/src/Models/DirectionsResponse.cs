using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Stores all serialized data from API Directions response
    /// </summary>
    public class DirectionsResponse 
    {
        private List<Route> _routes { get; set; }
        private List<Object> _waypoints { get; set; }
        private string _code { get; set; }
        private string _uuid { get; set; }
        public DirectionsResponse(List<Route> routes, List<object> waypoints, string code, string uuid) {
            _routes = routes;
            _waypoints = waypoints;
            _code = code;
            _uuid = uuid;
        }
    }
}