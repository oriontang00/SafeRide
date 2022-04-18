using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Models;


namespace SafeRide.src.Models
{
   
    /// <summary>
    /// Enum which represents type of hazard.
    /// </summary>
    public class Hazard
    {
        private HazardType _type { get; set; }
        

        private double _latitude { get; set; }
        private double _longitude { get; set; }

        private DateTime _timeReported { get; set; }
    

        private string _state { get; set; }
        private int _zip { get; set; }
    
        private string _city { get; set; }
        

        private bool _isCleared { get; set; }
 
        private ApplicationUser _reportedBy { get; set; }

        public Hazard(HazardType type, double hazardX, double hazardY, ApplicationUser reportedBy, string state, int zip, string city)
        {
            _type = type;
            _latitude = hazardX;
            _longitude = hazardY;
            _reportedBy = reportedBy;
            _timeReported = DateTime.Now;
            _state = state;
            _zip = zip;
            _city = city;
            _isCleared = false;
        }
    }
}