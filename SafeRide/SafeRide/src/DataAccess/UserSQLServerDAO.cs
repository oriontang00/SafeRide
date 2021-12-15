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

        public List<bool> BulkOp(String path)
        {
            List<bool> result = new List<bool>();
           

            try
            {
                foreach (String line in System.IO.File.ReadLines(path))
                {
                    var value = line.Split(",");

                    if (value[0].Equals("create"))
                    {
                        User user = new User();
                        user.FirstName = value[1];
                        user.LastName = value[2];
                        user.UserName = value[3];
                        user.UserId = value[4];
                        user.PhoneNum = value[5];
                        user.Password = value[6];

                        result.Append(Create(user));
                        
                    }
                    else if (value[0].Equals("update"))
                    {

                    }
                    else if (value[0].Equals("delete"))
                    {

                    }
                    else if (value[0].Equals("enable"))
                    {

                    }
                    else if (value[0].Equals("disable"))
                    { 
                    
                    }
                    
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File is not found.");
            }

         
            
            return result;
        }
    }
}
