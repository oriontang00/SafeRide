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
    private const string SECOND_TABLE_NAME = "OverlaysColors";

    public OverlayStructureDAO(IConfiguration config)
    {
        builder = new SqlConnectionStringBuilder();
        builder.DataSource = "saferidesql.database.windows.net";
        builder.UserID = "saferideapple";
        builder.Password = config["AppKey:DBKey"];
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
        string query_two = $"SELECT OverlayColor FROM {SECOND_TABLE_NAME} WHERE OverlayName='{overlayName}'";

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

            using (var sqlConn = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query_two, sqlConn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var color = reader["OverlayColor"].ToString();
                            readModel.overlayColor = color;
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

    public bool AddOverlayPoint(string user, string overlayName, OverlayPoint newPoint)
    {
        string query =
            $"INSERT INTO {TABLE_NAME} values ('{overlayName}', '{user}', {newPoint.LatPoint}, {newPoint.LongPoint})";

        return ExecuteQuery.ExecuteCommand(builder.ConnectionString, query);
    }

    public bool RemoveOverlayPoint(string user, string overlayName, OverlayPoint newPoint)
    {
        string query = $"DELETE FROM {TABLE_NAME} where overlayName='{overlayName}' and UserName='{user}' and LatPoint='{newPoint.LatPoint}' and LongPoint='{newPoint.LongPoint}'";
        return ExecuteQuery.ExecuteCommand(builder.ConnectionString, query);
    }
}