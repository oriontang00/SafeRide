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
        private HazardType _type;
        public HazardType Type
        {
            get { return _type; }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
        }
        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
        }

        private DateTime _timeReported;
        public DateTime TimeReported
        {
            get { return _timeReported; }
        }

        private string _state;
        public string State
        {
            get { return _state; }
        }

        private int _zip;
        public int Zip
        {
            get { return _zip; }
        }

        private string _city;
        public string City
        {
            get { return _city; }
        }

        private bool _expired;
        public bool Expired
        {
            get { return _expired; }
        }

        private string _reportedBy;
        public string ReportedBy
        {
            get { return _reportedBy; }
        }

        public Hazard(HazardType type, double hazardX, double hazardY, string reportedBy, string state, int zip, string city)
        {
            _type = type;
            _latitude = hazardX;
            _longitude = hazardY;
            _reportedBy = reportedBy;
            _timeReported = DateTime.Now;
            _state = state;
            _zip = zip;
            _city = city;
            _expired = false;
        }
    }
}