using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SafeRide.src.DataAccess
{
    public class LogMessageSQLServerDAO : ILogMessageDAO
    {
        private string _cs;
        
        public LogMessageSQLServerDAO()
        {
            this._cs = System.Configuration.ConfigurationManager.ConnectionStrings["SafeRideDB"].ConnectionString;
        }
        
        public int Create(LogMessage message)
        {
            int numRowsAffected;
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "INSERT INTO Logs (Level, Text, timeLogged) VALUES (@param1, @param2, @param3)";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = message.LogLevel;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 255).Value = message.Text;
                    cmd.Parameters.Add("@param3", SqlDbType.DateTime).Value = message.Time;
                    numRowsAffected = cmd.ExecuteNonQuery();
                }
            }
            //ExecuteNonQuery() returns the number of rows affected, ideally for this function it should be 1
            //we use this to check if the message was succesfully inserted into database
            return numRowsAffected;
        }

        public List<LogMessage> GetByLevel(Level desiredLevel)
        {
            List<LogMessage> logList = new List<LogMessage>();
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "SELECT * FROM Logs WHERE Level = @param1 ORDER BY timeLogged";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = desiredLevel;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Level level = (Level)reader.GetInt32(0);
                            string text = reader.GetString(1);
                            DateTime time = reader.GetDateTime(2);
                            LogMessage message = new LogMessage(text, level, time);
                            logList.Add(message);
                        }
                    }
                }
            }

            return logList;
        }

        public List<LogMessage> GetByTimeRange(DateTime start, DateTime end)
        {
            List<LogMessage> logList = new List<LogMessage>();
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "SELECT * FROM Logs WHERE timeLogged BETWEEN @param1 AND @param2 ORDER BY timeLogged";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.DateTime).Value = start;
                    cmd.Parameters.Add("@param2", SqlDbType.DateTime).Value = end;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Level level = (Level)reader.GetInt32(0);
                            string text = reader.GetString(1);
                            DateTime time = reader.GetDateTime(2);
                            LogMessage message = new LogMessage(text, level, time);
                            logList.Add(message);
                        }
                    }
                }
            }

            return logList;
        }

        public int DeleteByLevel(Level level)
        {
            int numRowsAffected;
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "DELETE FROM Logs WHERE Level = @param1";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = level;
                    numRowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return numRowsAffected;
        }

        public int DeleteByTimeRange(DateTime start, DateTime end)
        {
            int numRowsAffected;
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "DELETE FROM Logs WHERE timeLogged BETWEEN @param1 AND @param2";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.DateTime).Value = start;
                    cmd.Parameters.Add("@param2", SqlDbType.DateTime).Value = end;
                    numRowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return numRowsAffected;
        }

        public List<LogMessage> GetAllLogs()
        {
            List<LogMessage> logList = new List<LogMessage>();
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                string queryString = "SELECT * FROM Logs ORDER BY timeLogged";
                using (SqlCommand cmd = new SqlCommand(queryString, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Level level = (Level)reader.GetInt32(0);
                            string text = reader.GetString(1);
                            DateTime time = reader.GetDateTime(2);
                            LogMessage message = new LogMessage(text, level, time);
                            logList.Add(message);
                        }
                    }
                }
            }

            return logList;
        }
    }
}
