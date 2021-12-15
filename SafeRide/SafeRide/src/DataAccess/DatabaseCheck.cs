using System.Data;
using System.Data.SqlClient;

namespace SafeRide.src.DataAccess
{
    public class DatabaseCheck
    {
        //https://stackoverflow.com/questions/2232227/check-if-database-exists-before-creating
        public bool CheckDatabaseExists(string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                SqlConnection tmpConn = new SqlConnection(@"server=(local)\SQLExpress;integrated Security=SSPI;");

                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        //https://stackoverflow.com/questions/9015142/creating-a-database-programmatically-in-sql-server
        public void CreateDatabase(string db_name)
        {
            SqlConnection myConn = new SqlConnection(@"server=(local)\SQLExpress;database=master;integrated Security=SSPI;");

            using (myConn)
            {
                myConn.Open();
                var command = myConn.CreateCommand();
                command.CommandText = $"CREATE DATABASE {db_name}";
                command.ExecuteNonQuery();
            }
        }

        //https://www.completecsharptutorial.com/ado-net/c-ado-net-create-rename-alter-and-delete-table.php
        public void CreateTables()
        {
            SqlConnection myConn = new SqlConnection(@"server=(local)\SQLExpress;database=master;integrated Security=SSPI;");
            string query =
            @"CREATE TABLE Logs
            (
                Level        INT        NOT NULL,
                Text        VARCHAR(255)    NOT NULL,
                timeLogged     datetime    NOT NULL,

            );

            CREATE TABLE Users
            (
                firstName    VARCHAR(32)    NOT NULL,
                lastName    VARCHAR(32)    NOT NULL,
                userName    VARCHAR(32)    NOT NULL,
                userID        VARCHAR(32)    NOT  NULL,
                phoneNum    VARCHAR(32)    NOT NULL,
                password    VARCHAR(32)    NOT NULL, 
                isAdmin    BIT              NOT NULL,
                enabled     BIT             NOT NULL,

            );";
            SqlCommand cmd = new SqlCommand(query, myConn);
            try
            {
                myConn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tables Created Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                myConn.Close();
                Console.ReadKey();
            }
        }
    }
}
