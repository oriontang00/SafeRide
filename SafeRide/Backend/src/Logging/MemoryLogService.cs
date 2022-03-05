using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Logging
{

    /// <summary>
    /// This class simulates a logger in memory by storing logs in a list. No database required.
    /// </summary>
    public class MemoryLogService : ILogService
    {
        private List<LogMessage> _logList;

        public List<LogMessage> LogList
        {
            get { return _logList; }
        }

        /// <summary>
        /// Constructor which instantiates the log list.
        /// </summary>
        public MemoryLogService()
        {
            _logList = new List<LogMessage>();
        }

        /// <summary>
        /// Adds the specified log message to the in-memory list.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <returns>A boolean value representing the success status of the insertion</returns>
        public bool Write(LogMessage message)
        {
            int lengthBefore = _logList.Count;
            _logList.Add(message);
            int lengthAfter = _logList.Count;

            if (lengthAfter - lengthBefore == 1)
                return true;
            return false;
        }
    }
}
