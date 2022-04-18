using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data;
using System.Data.SqlClient;
using SafeRide.src.Models;

namespace SafeRide.src.DataAccess
{
    public class HazardDAO : IHazardDAO
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["SafeRideDB"].ConnectionString;
        private ApplicationUser _user;
        private Hazard _hazard;

        public HazardDAO() {
            this._user = new ApplicationUser();
        }

        public HazardDAO(ApplicationUser user, Hazard hazard) {

            this._user = user;
            this._hazard = hazard;
        }

        public Dictionary<double, double> FindHazardInRadius(HazardType hazardType, double searchX, double targetY, double radius) {
            // initialize empty dictionary of doubles to store the set of queried coordinates
            Dictionary<double, double> foundCoordinates = new Dictionary<double, double>();
            // convert meters from meters to miles
            const float RADIUS_MILES = radius * 0.000621371;

            // attempt connecting to the database to query for mathing hazards
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    
                    // build query using trigonometry function to search for the coordinates of all hazards of the provided type within the set radius around a coordinate defined by the provided targetX and targetY values
                    string queryString = $"SELECT latitude, longitude FROM Hazards WHERE hazardType = '{hazardType}' AND (acos(sin(latitude * 0.0175) * sin({targetX} * 0.0175) + cos(latitude * 0.0175) * cos({targetX} * 0.0175) * cos(({targetY} * 0.0175) - ({targetY} * 0.0175)) * 3959 <= {RADIUS_MILES})";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn)) 
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // add each set of queried coordinates to the return dictionary
                                double hazardX = (double) (reader["latitude"] ?? 0);
                                double hazardY = (double) (reader["longitude"] ?? 0);
                                foundCoordinates.Add(hazardX, hazardY);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return foundCoordinates;
            }
            return foundCoordinates;
        }

        public bool Report(ApplicationUser user, HazardType type, double hazardX, double hazardY) {
        }
    }
}
