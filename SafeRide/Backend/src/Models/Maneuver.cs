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


        private string _type;
        private string _instruction;
        private string _modifier;
        private double _bearingAfter;
        private double _bearingBefore;
        private double[] _location;

        public Maneuver(string type, string instruction, string modifier, double bearingAfter, double bearingBefore, double[] location)
        {
            _type = type;
            _instruction = instruction;
            _modifier = modifier;
            _bearingAfter = bearingAfter;
            _bearingBefore = bearingBefore;
            _location = location;
        }

        public string Type { get => _type; set => _type = value; }
        public string Instruction { get => _instruction; set => _instruction = value; }
        public string Modifier { get => _modifier; set => _modifier = value; }
        public double BearingAfter { get => _bearingAfter; set => _bearingAfter = value; }
        public double BearingBefore { get => _bearingBefore; set => _bearingBefore = value; }
        public double[] Location { get => _location; set => _location = value; }
    }
}