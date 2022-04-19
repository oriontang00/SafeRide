using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Holds data from API response grouped by coords; 
    /// </summary>
    public class Coordinate {
        private double _latitude { get; }
        private double _longitude { get; }
        public Coordinate(double latitude, double longitude) {
            this._latitude = latitude;
            this._longitude = longitude;
        }
    }
}
    