using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    /// <summary>
    /// This interface declares features for classes which handle logging for the system.
    /// </summary>
    interface ILogService
    {
        /// <summary>
        /// A class implementing this method needs to provide functionality to log the message
        /// to the proper location.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <returns>A boolean value representing the success status of logging the message</returns>
        public bool Write(LogMessage message);
    }
}
