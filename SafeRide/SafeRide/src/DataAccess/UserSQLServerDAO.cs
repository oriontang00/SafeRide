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
            string isAdmin = "";
            string enabled = "";

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
                            isAdmin = reader["isAdmin"].ToString() ?? "0"; // defaults to false
                            enabled = reader["enabled"].ToString() ?? "1"; // defaults to true
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new User();
            }

            return new User(firstName, lastName, userName, password, UserId, phoneNum, isAdmin, enabled);
        }

        public bool Update(String UserId, User User)
        {
            /*string query = "Update User set" +
                $" (FirstName=' " + User.FirstName + "', LastName='" + User.LastName + "', Phone Number='" + User.PhoneNum + " )" +
                $" where userID={UserId}";
            string query = "UPDATE database.SafeRide_DB SET firstName= '" + User.FirstName + "', lastName='" + User.LastName + "', userName='" + User.UserName + "', UserId= '" + User.UserId + "', phoneNum='" + User.PhoneNum + "', password='" + User.Password +
                 " 'where userID='" + UserId ;
  
            sqlConn = new SqlConnection(CONNECTION_STRING);
            sqlConn.Open();
            SqlCommand _cmd = new SqlCommand("UPDATE Users SET firstName=@FirstName WHERE userID=UserId", sqlConn);
            _cmd.Parameters.Add(User.FirstName );
            _cmd.ExecuteNonQuery(); */

            string query = "update Users set " +
                $"firstName='{User.FirstName}',lastName='{ User.LastName} ',userName= '{ User.UserName} ',phoneNum= '{ User.PhoneNum}' " +
                $"where userID= '{UserId}'";
            //SqlConnection _con = new SqlConnection(CONNECTION_STRING);
            //SqlCommand _cmd = new SqlCommand(query, _con);
            //_con.Open();
            //_cmd.ExecuteNonQuery();
            Console.WriteLine(query);
            return ExecuteCommand(query);
            //return true;
        }

        public bool Delete(String UserId)
        {
            String query = $"DELETE FROM Users WHERE userID = '{UserId}'";
            return ExecuteCommand(query);
        }

        public bool Enable(String UserId)
        {
            string query = $"UPDATE Users SET enabled = 1 WHERE userId = {UserId}";
            return ExecuteCommand(query);
        }

        public bool Disable(String UserId)
        {
            string query = $"UPDATE Users SET enabled = 0 WHERE userId = {UserId}";
            return ExecuteCommand(query);
        }
    }
}
