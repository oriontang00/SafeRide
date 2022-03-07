using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data.SqlClient;

namespace SafeRide.src.DataAccess
{
    public class UserSQLServerDAO : IUserDAO
    {
        private const string CONNECTION_STRING = @"server=(local)\SQLExpress;database=SafeRide_DB;integrated Security=SSPI;";
        private UserModel User;
        private string UserId;

        public UserSQLServerDAO()
        {
            this.User = new UserModel();
            this.UserId = "";
        }
        public UserSQLServerDAO(UserModel User, String UserId)
        {
            this.User = User;
            this.UserId = UserId;
        }

        private bool ExecuteCommand(string queryStr)
        {
            try
            {
                using (var sqlConn = new SqlConnection(CONNECTION_STRING))
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
        public bool Create(UserModel User)
        {
            string query = "INSERT INTO Users (firstName, lastName, userName, userID, phoneNum, password, isAdmin, enabled) VALUES" +
                $" ('{User.FirstName}', '{User.LastName}', '{User.UserName}', '{User.UserId}', '{User.PhoneNum}', '{User.Password}'" +
                $" ,'{User.IsAdmin}', '{User.Enabled}');";
            Console.WriteLine(query);
            return ExecuteCommand(query);
        }
        public UserModel Read(String UserId)
        {
            string query = $"SELECT * FROM Users WHERE userID='{UserId}'";

            string firstName = "";
            string lastName = "";
            string userName = "";
            string phoneNum = "";
            string password = "";
            string isAdmin = "";
            string enabled = "";

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
                                firstName = (reader["firstName"].ToString() ?? "").Trim();
                                lastName = (reader["lastName"].ToString() ?? "").Trim();
                                userName = (reader["userName"].ToString() ?? "").Trim();
                                phoneNum = (reader["phoneNum"].ToString() ?? "").Trim();
                                password = (reader["password"].ToString() ?? "").Trim();
                                isAdmin = (reader["isAdmin"].ToString() ?? "0").Trim(); // defaults to false
                                if (isAdmin.Equals("True")) { isAdmin = "1"; } else { isAdmin = "0"; }
                                enabled = reader["enabled"].ToString() ?? "1"; // defaults to true
                                if (enabled.Equals("True")) { enabled = "1"; } else { enabled = "0"; };
                            }
                        }
                    }
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new UserModel();
            }

            return new UserModel(firstName, lastName, userName, password, UserId, phoneNum, isAdmin, enabled);
        }

        public bool Update(String UserId, UserModel User)
        {
            string query = "update Users set " +
                $"firstName='{User.FirstName}',lastName='{ User.LastName} ',userName= '{ User.UserName} ',phoneNum= '{ User.PhoneNum}'," +
                $" password='{User.Password}', isAdmin='{User.IsAdmin}', enabled='{User.Enabled}' " +
                $"where userID= '{UserId}'";

            Console.WriteLine(query);
            return ExecuteCommand(query);
        }

        public bool Delete(String UserId)
        {
            String query = $"DELETE FROM Users WHERE userID = '{UserId}'";
            return ExecuteCommand(query);
        }

        public bool Enable(String UserId)
        {
            string query = $"UPDATE Users SET enabled = 1 WHERE userId = '{UserId}'";
            return ExecuteCommand(query);
        }

        public bool Disable(String UserId)
        {
            string query = $"UPDATE Users SET enabled = 0 WHERE userId = '{UserId}'";
            return ExecuteCommand(query);
        }
    }
}
