namespace Backend.src.Models
{
    /// <summary>
    /// Enum which represents type of hazard.
    /// </summary>
    public enum HazardType
    {
        Accident,
        Obstruction,
        BikeLane,
        Vehicle,
        Closure
    }

    public class Hazard
    {
        private HazardType _type;
        public HazardType Type
        {
            get { return _type; }
        }

        private Coordinate _location;
        public Coordinate Location
        {
            get { return _location; }
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

        private bool _isCleared;
        public bool IsCleared
        {
            get { return _isCleared; }
        }

        private UserHash _reportedBy;
        public UserHash ReportedBy
        {
            get { return _reportedBy; }
        }

        public Hazard(HazardType type, Coordinate location, UserHash reportedBy, DateTime timeReported, string state, int zip, string city)
        {
            _type = type;
            _location = location;
            _reportedBy = reportedBy;
            _timeReported = timeReported;
            _state = state;
            _zip = zip;
            _city = city;
            _isCleared = false;
        }
    }
}
