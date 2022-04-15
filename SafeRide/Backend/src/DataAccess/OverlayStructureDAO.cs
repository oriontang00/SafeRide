using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.DataAccess;

public class OverlayStructureDAO : IOverlayStructureDAO
{
    private SqlConnectionStringBuilder builder;
    private const string TABLE_NAME = "OverlayDimensions";

    public OverlayStructureDAO()
    {
        builder = new SqlConnectionStringBuilder();
        builder.DataSource = "saferidesql.database.windows.net";
        builder.UserID = "saferideapple";
        builder.Password = "t^E~eT1+$~O5qjY6mS`PTVY=N$pOiNNR";
        builder.InitialCatalog = "SafeRide_DB";
    }

    public List<string> GetAvailableOverlays(string userName)
    {
        var overlays = new HashSet<string>();
        string query = $"SELECT OverlayName FROM {TABLE_NAME} WHERE UserName='{userName}'";

        try
        {
            using (var sqlConn = new SqlConnection(builder.ConnectionString))
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

        return overlays.ToList();
    }
    public OverlayStructureModel GetOverlay(string userName, string overlayName)
    {
        string query = $"SELECT * FROM {TABLE_NAME} WHERE OverlayName='{overlayName}' AND UserName='{userName}'";

        var readModel = new OverlayStructureModel(overlayName);
        var dimensions = new List<OverlayPoint>();

        try
        {
            using (var sqlConn = new SqlConnection(builder.ConnectionString))
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