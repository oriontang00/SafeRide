using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data;
using System.Data.SqlClient;

namespace SafeRide.src.DataAccess
{
    public class ViewEventSQLServerDAO : IViewEventDAO
    {
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["SafeRideDB"].ConnectionString;

        public int CreateViewEvent(ViewEvent viewEvent)
        {
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    string queryString = "INSERT INTO ViewEvents (userId, viewURL, startDate, endDate, elapsedSeconds) VALUES (@param1, @param2, @param3, @param4, @param5)";
                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.VarChar, 32).Value = viewEvent.UserId;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 64).Value = viewEvent.ViewURL;
                        cmd.Parameters.Add("@param3", SqlDbType.DateTime).Value = viewEvent.StartDate;
                        cmd.Parameters.Add("@param4", SqlDbType.DateTime).Value = viewEvent.EndDate;
                        cmd.Parameters.Add("@param5", SqlDbType.Float).Value = viewEvent.ElapsedSeconds;
                       return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public Dictionary<string, double> GetTopFiveDurations()
        {
            Dictionary<string, double> results = new Dictionary<string, double> ();

            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "SELECT TOP(5) viewURL, SUM(elapsedSeconds) AS totalSeconds FROM ViewEvents GROUP BY viewURL ORDER BY totalSeconds DESC";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string viewURL = (reader["viewURL"].ToString() ?? "").Trim();
                            double totalSeconds = (double)(reader["totalSeconds"] ?? 0);
                            results.Add(viewURL, totalSeconds);
                        }
                    }
                }
            }
            return results;
        }

        public Dictionary<string, int> GetTopFiveViews()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "SELECT TOP(5) viewURL, COUNT(viewURL) AS numViews FROM ViewEvents GROUP BY viewURL ORDER BY numViews DESC";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string viewURL = (reader["viewURL"].ToString() ?? "").Trim();
                            int numViews = (int)(reader["numViews"] ?? 0);
                            results.Add(viewURL, numViews);
                        }
                    }
                }
            }
            return results;
        }
    }
}
