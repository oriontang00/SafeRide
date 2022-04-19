using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Holds data for the Route object from the API response; 
    /// each maneuver represents a part of the route where the direction has changed 
    /// </summary>
    public class Route : IRoute
    {  
        private string _weightName { get; set; }
        private double _weight { get; set; }
        private double _duration { get; set; }
        private double _distance { get; set; }
        private List<Object> _legs { get; set; }
        private string _geometry { get; set; }

        public Route(string weightName, double weight, double duration, double distance, List<object> legs, string geometry, string weightName, double weight, double duration, double distance, List<Leg> legs, string geometry) {
            this._weightName = weightName;
            this._weight = weight;
            this._duration = duration;
            this._distance = distance;
            this._legs = legs;
            this._geometry = geometry;
            this._weightName = weightName;
            this._weight = weight;
            this._duration = duration;
            this.distance = distance;
            this._legs = legs;
            this._geometry = geometry;
        }
    }
}