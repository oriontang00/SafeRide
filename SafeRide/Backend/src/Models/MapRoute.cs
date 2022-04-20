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
    public class MapRoute
    {
        private string _weightName;
        private double _weight;
        private double _duration;
        private double _distance;
        private List<Leg> _legs;
        private string _geometry;

        public MapRoute(string weightName, double weight, double duration, double distance, List<Leg> legs, string geometry) {
            this._weightName = weightName;
            this._weight = weight;
            this._duration = duration;
            this._distance = distance;
            this._legs = legs;
            this._geometry = geometry;
        }

        public string WeightName { get => _weightName; set => _weightName = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Duration { get => _duration; set => _duration = value; }
        public double Distance { get => _distance; set => _distance = value; }
        public List<Leg> Legs { get => _legs; set => _legs = value; }
        public string Geometry { get => _geometry; set => _geometry = value; }
    }
}