using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    /// <summary>
    /// This interface defines what features an archive service that handles log messages should implement.
    /// </summary>
    public interface ILogArchiveService
    {
        /// <summary>
        /// A class implementing this method needs to provide functionality to return
        /// archiveable logs, depending on the required definition of archiveable.
        /// </summary>
        /// <returns> A list containing LogMessages that are deemed archiveable </returns>
        public List<LogMessage> GetArchiveableLogs();

        /// <summary>
        /// A class implementing this method needs to provide functioanlity to delete
        /// archiveable logs, depending on the required definition of archiveable.
        /// Logs are archiveable if more than 30 days have elapsed since the date of insertion.
        /// </summary>
        /// <returns> An integer representing the number of rows deleted</returns>
        public int RemoveArchivedLogs();

        /// <summary>
        /// A class implementing this interface needs to have a FilePath property.
        /// </summary>
        string FilePath
        {
            get;
        }
    }
}
