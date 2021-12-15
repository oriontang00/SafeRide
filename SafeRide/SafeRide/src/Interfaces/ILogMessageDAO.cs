using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    /// <summary>
    /// This interface declares features for classes that need to communicate with the database responsible for holding
    /// Log Messages.
    /// </summary>
    public interface ILogMessageDAO
    {
        /// <summary>
        /// A class implementing this method needs to provide functionality to insert 
        /// a log message into the database.
        /// </summary>
        /// <param name="message">The message to be inserted into the database</param>
        /// <returns>An integer representing number of rows affected</returns>
        public int Create(LogMessage message);

        /// <summary>
        /// A class implementing this method needs to provide functionality to retrieve
        /// log messages by their level.
        /// </summary>
        /// <param name="level">The level which logs must have to be returned</param>
        /// <returns>A list of log messages with the specified log level</returns>
        public List<LogMessage> GetByLevel(Level level);

        /// <summary>
        /// A class implementing this method needs to provide functionality to retrieve
        /// log messages within the specified time range.
        /// </summary>
        /// <param name="start">The start date for the range</param>
        /// <param name="end">The end date for the range</param>
        /// <returns>A list of log messages between the specified start and end dates</returns>
        public List<LogMessage> GetByTimeRange(DateTime start, DateTime end);

        /// <summary>
        /// A class implementing this method needs to provide functionality to delete
        /// log messages with the specified level.
        /// </summary>
        /// <param name="level">The level which logs must have to be deleted</param>
        /// <returns>An integer representing the number of rows affected</returns>
        public int DeleteByLevel(Level level);

        /// <summary>
        /// A class implementing this method needs to provide functionality to delete 
        /// log message within the specified range.
        /// </summary>
        /// <param name="start">The start date for the range</param>
        /// <param name="end">The end date for the range</param>
        /// <returns>An integer representing the number of rows affected</returns>
        public int DeleteByTimeRange(DateTime start, DateTime end);

        /// <summary>
        /// A class implementing this method needs to provide functionality to retrieve
        /// all logs in the database.
        /// </summary>
        /// <returns>A list of all log messages in the database</returns>
        public List<LogMessage> GetAllLogs();

    }
}
