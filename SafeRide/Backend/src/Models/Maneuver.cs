using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Holds data from API response grouped by maneuvers; 
    /// each maneuver represents a part of the route where the direction has changed 
    /// </summary>
    public class Maneuver {
        private string _type { get; }
        private string _instruction { get; }
        private string _modifier { get; }
        private double _bearing_after { get; }
        private double _bearing_before { get; }
        private List<double, double> _location { get; }

        public Maneuver(string type, string instruction, string modifier, double bearing_after, double bearing_before, List<double, double> location) {
            _type = type;
            _instruction = instruction;
            _modifier = modifier;
            _bearing_after = bearing_after;
            _bearing_before = bearing_before;
            _location = location;
        }
    }
}