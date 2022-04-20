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
    public class Step {
        private List<Object> _intersections;
        private Maneuver _maneuver;
        private string _name;
        private double _duration;
        private double _distance;
        private string _drivingSide;
        private double _weight;
        private string _mode;
        private string _geometry;

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

        public List<object> Intersections { get => _intersections; set => _intersections = value; }
        public Maneuver Maneuver { get => _maneuver; set => _maneuver = value; }
        public string Name { get => _name; set => _name = value; }
        public double Duration { get => _duration; set => _duration = value; }
        public double Distance { get => _distance; set => _distance = value; }
        public string DrivingSide { get => _drivingSide; set => _drivingSide = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public string Mode { get => _mode; set => _mode = value; }
        public string Geometry { get => _geometry; set => _geometry = value; }
    }
}