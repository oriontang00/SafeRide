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

    private string _overlay;
    
    public OverlayStructureDAO(string overlay)
    {
        _overlay = overlay;
    }

    public OverlayStructureModel GetOverlay(string overlayName)
    {
        string query = $"SELECT * FROM {TABLE_NAME} WHERE OverlayID='{overlayName}'";

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