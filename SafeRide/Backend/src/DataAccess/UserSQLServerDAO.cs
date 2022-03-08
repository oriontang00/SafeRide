using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data;
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
                $" ,'{User.IsAdmin}', '{User.Enabled}', '{User.LastLogin}', '{User.DateRegistered});";
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
            DateTime lastLogin = default;
            DateTime dateRegistered = default;

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
                                lastLogin = DateTime.Parse((reader["lastLogin"].ToString() ?? "").Trim());
                                dateRegistered = DateTime.Parse((reader["dateRegistered"].ToString() ?? "").Trim());
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

            return new UserModel(firstName, lastName, userName, password, UserId, phoneNum, isAdmin, enabled, lastLogin, dateRegistered);
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

        public Dictionary<string, int> GetLastThreeMonthLogins()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            string query = $"SELECT CONVERT(DATE, lastLogin) AS loginDate, COUNT(userName) AS numLogins FROM Users WHERE lastLogin >= DATEADD(M, -3, GETDATE()) GROUP BY lastLogin";

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
                                DateTime loginDate = (DateTime)reader["loginDate"];
                                int numLogins = (int)(reader["numLogins"] ?? 0);
                                result.Add(loginDate.ToString("M/d/yyyy"), numLogins);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }

            return result;
        }

        public Dictionary<string, int> GetLastThreeMonthRegistrations()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            string query = $"SELECT CONVERT(DATE, dateRegistered) AS registerDate, COUNT(userName) AS numRegisters FROM Users WHERE dateRegistered >= DATEADD(M, -3, GETDATE()) GROUP BY dateRegistered";

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
                                DateTime registerDate = (DateTime)reader["registerDate"];
                                int numRegisters = (int)(reader["numRegisters"] ?? 0);
                                result.Add(registerDate.ToString("M/d/yyyy"), numRegisters);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }

            return result;
        }

        public int UpdateLastLogin(string userId, DateTime dateTime)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                string query = $"UPDATE Users SET lastLogin = '{dateTime}' WHERE userID = '{userId}'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
