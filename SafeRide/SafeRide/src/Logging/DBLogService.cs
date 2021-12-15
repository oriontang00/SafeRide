using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Logging
{
    /// <summary>
    /// This class defines functionality to log messages from anywhere within the system.
    /// </summary>
    public class DBLogService : ILogService
    {
        private ILogMessageDAO _logMessageDAO;

       /// <summary>
       /// Constructor which instantiates an ILogMessageDAO object to let this class communicate with the database.
       /// </summary>
        public DBLogService()
        {
            _logMessageDAO = new LogMessageSQLServerDAO();
        }

        /// <summary>
        /// Passes the log message to be logged to the data access object to insert to database.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <returns>A boolean value representing success status of inserting message into database</returns>
        public bool Write(LogMessage message)
        {

            //if the Create method of the data access object only affects one row, return true
            if (_logMessageDAO.Create(message) == 1)
                return true;
            //else operation failed, return false
            return false;

        }
    } 
}
