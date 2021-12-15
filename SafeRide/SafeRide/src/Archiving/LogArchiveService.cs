using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Archiving
{
    /// <summary>
    /// This class defines functionality dealing with archiving log messages from a database.
    /// </summary>
    public class LogArchiveService : ILogArchiveService
    {
        private ILogMessageDAO _logMessageDAO;
        private DateTime _thirtyDaysAgo = DateTime.Now.AddDays(-30);
        
        /// <summary>
        /// This field will add the current day to the "FileSuffix" defined in the config file, 
        /// to represent when this file was created.
        /// </summary>
        private string _filePath = DateTime.Now.ToString("yyyy-MM-dd") + System.Configuration.ConfigurationManager.AppSettings["FileSuffix"];

        /// <summary>
        /// Gets the filepath associated with this LogArchiveService object. 
        /// Taken from App.config file.
        /// </summary>
        public string FilePath {
            get {return _filePath; } 
        }

        /// <summary>
        /// Constructor for a LogArchiveService object.
        /// Instantiates an ILogMessageDAO object in order to communicate with the database.
        /// </summary>
        public LogArchiveService()
        {
            this._logMessageDAO = new LogMessageSQLServerDAO();
        }

        /// <summary>
        /// Gets all archiveable logs. 
        /// Logs are archiveable if more than thirty days have elapsed since the date of insertion.
        /// </summary>
        /// <returns> A list containing LogMessages over 30 days old</returns>
        public List<LogMessage> GetArchiveableLogs()
        {
            List<LogMessage> logList = new List<LogMessage>();
            DateTime start = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            
            logList = _logMessageDAO.GetByTimeRange(start, _thirtyDaysAgo);

            return logList;
        }

        /// <summary>
        /// Removes archiveable logs. 
        /// Logs are archiveable if more than 30 days have elapsed since the date of insertion.
        /// </summary>
        /// <returns> An integer representing the number of rows deleted</returns>
        public int RemoveArchivedLogs()
        {
            DateTime start = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            return _logMessageDAO.DeleteByTimeRange(start, _thirtyDaysAgo);
        }
    }
}
