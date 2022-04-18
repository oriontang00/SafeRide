namespace Backend.src.Models
{
    public class Coordinate
    {
        private float _latitude;
        public float Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private float _longitude;
        public float Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public Coordinate(float latitude, float longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }
    }
}
