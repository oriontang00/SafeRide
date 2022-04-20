using System.Data.SqlClient;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.DataAccess;

public class UserSQLSecurityDAO : IUserSecurityDAO
{
    private string _cs = "Data Source = tcp:saferidedbserver.database.windows.net,1433;Initial Catalog = SafeRide_db; User Id = SafeRideAdmin@saferidedbserver;Password=applepw123!";
    private const string TABLE_NAME = "UserSecurity";

    public UserSQLSecurityDAO()
    {
    }
    
    private bool ExecuteCommand(string queryStr)
    {
        try
        {
            using (var sqlConn = new SqlConnection(_cs))
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
    
    public bool Create(UserSecurityModel user)
    {
        string query = $"INSERT INTO {TABLE_NAME} (username, email, role, valid) VALUES" +
                       $" ('{user.UserName}', '{user.Email}', '{user.Role}', '{user.Valid}');";

        Console.WriteLine(query);
        return ExecuteCommand(query);
    }

    public UserSecurityModel Read(string username)
    {
        string query = $"SELECT * FROM {TABLE_NAME} WHERE username='{username}'";

        UserSecurityModel readModel = new UserSecurityModel();

        try
        {
            using (var sqlConn = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            readModel.UserName = (reader["username"].ToString() ?? "").Trim();
                            readModel.Email = (reader["email"].ToString() ?? "").Trim();
                            readModel.Role = (reader["role"].ToString() ?? "").Trim();
                            readModel.Valid = reader["valid"].Equals("1"); // defaults to false
                        }
                    }
                }
            }
        }
           
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return readModel;
        }

        return readModel;
    }

    public bool Update(string username, UserSecurityModel user)
    {
        string query = $"update {TABLE_NAME} set " +
                       $"username='{user.UserName}', email='{user.Email}',role='{user.Role}', valid='{user.Valid}' " +
                       $"where username='{user.UserName}';";

        Console.WriteLine(query);
        return ExecuteCommand(query);
    }

    public bool Delete(string username)
    {
        String query = $"DELETE FROM {TABLE_NAME} WHERE username = '{username}'";
        return ExecuteCommand(query);
    }
}