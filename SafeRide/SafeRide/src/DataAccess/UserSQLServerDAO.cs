using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data.SqlClient;

namespace SafeRide.src.DataAccess
{
    public class UserSQLServerDAO : IUserDAO
    {
        private const string CONNECTION_STRING = @"server=(local)\SQLExpress;database=SafeRide_DB;integrated Security=SSPI;";
        private SqlConnection sqlConn;
        private User User;
        private string UserId;

        public UserSQLServerDAO()
        {
            this.User = new User();
            this.UserId = "";
            this.sqlConn = new SqlConnection(CONNECTION_STRING);
        }
        public UserSQLServerDAO(User User, String UserId)
        {
            this.User = User;
            this.UserId = UserId;
            this.sqlConn = new SqlConnection(CONNECTION_STRING);
        }

        private bool CheckBulkOp(string bulkOps)
        {
            long numLines = bulkOps.Split("\n").Length;

            if (numLines > 10000) return false;

            return true;
        }

        static bool CheckFile(string filePath)
        {
            long fileSize = 0;
            long lineCount = 0;

            try
            {
                lineCount = File.ReadLines(filePath).Count();
                fileSize = new FileInfo(filePath).Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (fileSize == 0 || lineCount == 0 || fileSize > 2e+9 || lineCount > 10000) return false;

            return true;
        }

        private bool ExecuteCommand(string queryStr)
        {
            try
            {
                using (sqlConn)
                {
                    SqlCommand cmd = new SqlCommand(queryStr, sqlConn);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // logger here
                return false;
            }
        }
        public bool Create(User User)
        {
            string query = "INSERT INTO Users (firstName, lastName, userName, userID, phoneNum, password) VALUES" +
                $" ('{User.FirstName}', '{User.LastName}', '{User.UserName}', '{User.UserId}', '{User.PhoneNum}', '{User.Password}');";
            Console.WriteLine(query);
            return ExecuteCommand(query);
        }

        public User Read(String UserId)
        {
            string query = $"SELECT * FROM Users WHERE userID='{UserId}'";

            string firstName = "";
            string lastName = "";
            string userName = "";
            string phoneNum = "";
            string password = "";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            firstName = reader["firstName"].ToString() ?? "";
                            lastName = reader["lastName"].ToString() ?? "";
                            userName = reader["userName"].ToString() ?? "";
                            phoneNum = reader["phoneNum"].ToString() ?? "";
                            password = reader["password"].ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new User();
            }

            return new User(firstName, lastName, userName, password, UserId, phoneNum);
        }

        public bool Update(String UserId, User User)
        {
            return false;
        }

        public bool Delete(String UserId)
        {
            return false;
        }

        public bool Enable(String UserId)
        {
            return false;
        }

        public bool Disable(String UserId) 
        { 
            return false; 
        }
    }
}
