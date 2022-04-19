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
        private string _weightName { get; }
        private double _weight { get; }
        private double _duration { get; }
        private double _distance { get; }
        private List<Object> _legs { get; }
        private string _geometry { get; }

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