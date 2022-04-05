using System.Data.SqlClient;

namespace SafeRide.src.DataAccess;

public static class ExecuteQuery
{
    public static bool ExecuteCommand(string connectionString, string queryStr)
    {
        try
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryStr, sqlConn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // logger here
            return false;
        }
    }
}