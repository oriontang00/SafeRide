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
    public class Leg
    {
        private List<Object> _viaWaypoints;
        private List<Object> _admins;
        private double _weight;
        private double _duration;
        private List<Step> _steps;
        private double _distance;
        private string _summary;

        public Leg(List<object> viaWaypoints, List<object> admins, double weight, double duration, List<Step> steps, double distance, string summary)
        {
            _viaWaypoints = viaWaypoints;
            _admins = admins;
            _weight = weight;
            _duration = duration;
            _steps = steps;
            _distance = distance;
            _summary = summary;
        }

        public List<object> ViaWaypoints { get => _viaWaypoints; set => _viaWaypoints = value; }
        public List<object> Admins { get => _admins; set => _admins = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Duration { get => _duration; set => _duration = value; }
        public List<Step> Steps { get => _steps; set => _steps = value; }
        public double Distance { get => _distance; set => _distance = value; }
        public string Summary { get => _summary; set => _summary = value; }
    }
}

