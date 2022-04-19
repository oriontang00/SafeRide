using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.src.Interfaces;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Holds data for the Route object from the API response; 
    /// each maneuver represents a part of the route where the direction has changed 
    /// </summary>
    public class Step {
        private List<Object> _intersections { get; set; }
        private Maneuver _maneuver { get; set; }
        private string _name { get; set; }
        private double _duration { get; set; }
        private double _distance { get; set; }
        private string _drivingSide { get; set; }
        private double _weight { get; set; }
        private string _mode { get; set; }
        private string _geometry { get; set; }
        
        public Step(List<object> intersections, Maneuver maneuver, string name, double duration, double distance, string drivingSide, double weight, string mode, string geometry)
        {
            _intersections = intersections;
            _maneuver = maneuver;
            _name = name;
            _duration = duration;
            _distance = distance;
            _drivingSide = drivingSide;
            _weight = weight;
            _mode = mode;
            _geometry = geometry;
        }
    }
}