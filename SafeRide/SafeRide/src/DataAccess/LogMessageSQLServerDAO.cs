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
    /// <summary>
    /// This class defines functionality dealing with accessing log messages from a SQL Server database.
    /// </summary>
    public class LogMessageSQLServerDAO : ILogMessageDAO
    {
        /// <summary>
        /// The connection string is retrieved from the App.config file so it can be easily changed without having to refactor this code.
        /// </summary>
        private string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["SafeRideDB"].ConnectionString;
        
        /// <summary>
        /// Inserts a log message into the database's "Logs" table
        /// </summary>
        /// <param name="message">The message to be inserted</param>
        /// <returns>An integer representing the number of rows affected</returns>
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

        /// <summary>
        /// Gets all logs with the specified level from "Logs" table.
        /// </summary>
        /// <param name="desiredLevel">The level which logs must have to be returned</param>
        /// <returns>A list of log messages with the desired level</returns>
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

        /// <summary>
        /// Gets all logs within the specified time range from "Logs" table
        /// </summary>
        /// <param name="start">The start of the range</param>
        /// <param name="end">The end of the range</param>
        /// <returns>A list of log messages within the specified time range</returns>
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

        /// <summary>
        /// Deletes log messages with the specified level from "Logs" table.
        /// </summary>
        /// <param name="level">The level which log messages must have to be deleted.</param>
        /// <returns>An integer representing the number of rows affected.</returns>
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

        /// <summary>
        /// Deletes all logs within the specified range from the "Logs" table.
        /// </summary>
        /// <param name="start">The start of the range</param>
        /// <param name="end">The end of the range</param>
        /// <returns>An integer representing the number of rows affected</returns>
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

        /// <summary>
        /// Gets all log messages from the "Logs" table
        /// </summary>
        /// <returns>A list of all log messages</returns>
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
