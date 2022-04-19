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
        private List<Object> _viaWaypoints { get; set; }
        private List<Object> _admins { get; set; }
        private double _weight { get; set; }
        private double _duration { get; set; }
        private List<Step> _steps { get; set; }
        private double _distance { get; set; }
        private string _summary { get; set; }
        
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
    }
}