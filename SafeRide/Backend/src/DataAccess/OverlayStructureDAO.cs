using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.DataAccess;

public class OverlayStructureDAO : IOverlayStructureDAO
{
    private const string CONNECTION_STRING = @"server=(local)\SQLExpress;database=SafeRide_DB;integrated Security=SSPI;";
    private const string TABLE_NAME = "OverlayDimensions";

    public List<string> GetAvailableOverlays(string userName)
    {
        List<string> overlays = new List<string>();
        string query = $"SELECT OverlayName FROM {TABLE_NAME} WHERE UserName='{userName}'";

        try
        {
            using (var sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var overlayName = reader["OverlayName"].ToString();

                            overlays.Add(overlayName);
                        }
                    }
                }
            }
        }catch
        {
            // log error
        }

        return overlays;
    }
    public OverlayStructureModel GetOverlay(string userName, string overlayName)
    {
        string query = $"SELECT * FROM {TABLE_NAME} WHERE OverlayName='{overlayName}' AND UserName='{userName}'";

        OverlayStructureModel readModel = new OverlayStructureModel(overlayName);
        List<OverlayPoint> dimensions = new List<OverlayPoint>();

        try
        {
            using (var sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var latP = float.Parse(reader["LatPoint"].ToString(), CultureInfo.InvariantCulture);
                            var longP = float.Parse(reader["LongPoint"].ToString(), CultureInfo.InvariantCulture);
                            
                            dimensions.Add(new OverlayPoint(latP, longP));
                        }
                    }
                }
            }
            readModel.SetStructure(dimensions);
        }catch
        {
            // log error
        }

        return readModel;
    }
}