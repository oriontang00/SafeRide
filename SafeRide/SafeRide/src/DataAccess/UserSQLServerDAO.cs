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
                Console.WriteLine(ex.Message);
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
            return new User();
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
