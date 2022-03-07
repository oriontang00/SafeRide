using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Enum which represents the Level/Severity of a log.
    /// </summary>
    public enum Level
    {
        Debug,
        Information,
        Warn,
        Error,
        Fatal
    };

    /// <summary>
    /// This class models a log message object. 
    /// </summary>
    public class LogMessage
    {
        private string _text;
        public string Text
        {
            get { return _text; }
        }

        private DateTime _time;
        public DateTime Time
        {
            get { return _time; }
        }

        private Level _logLevel;
        public Level LogLevel
        {
            get { return _logLevel; }
        }

        /// <summary>
        /// Constructor for a log message that automatically sets the date to when the constructor was called.
        /// </summary>
        /// <param name="text">The textual decription of a log</param>
        /// <param name="level">The level/severity of a log</param>
        public LogMessage(string text, Level level)
        {
            this._text = text;
            this._logLevel = level;
            this._time = DateTime.Now;
        }

        /// <summary>
        /// Constructor for a log message with a specified date.
        /// </summary>
        /// <param name="text">The textual decription of a log</param>
        /// <param name="level">The level/severity of a log</param>
        /// <param name="time">The time to be set for this log message</param>
        public LogMessage(string text, Level level, DateTime time)
        {
            this._text = text;
            this._logLevel = level;
            this._time = time;
        }

        /// <summary>
        /// ToString method for a LogMessage object.
        /// </summary>
        /// <returns>A string representing the object</returns>
        public override string ToString()
        {
            string level = "";
            switch (this._logLevel)
            {
                case Level.Debug:
                    level = "Debug";
                    break;
                case Level.Information:
                    level = "Information";
                    break;
                case Level.Warn:
                    level = "Warn";
                    break;
                case Level.Error:
                    level = "Error";
                    break;
                case Level.Fatal:
                    level = "Fatal";
                    break;
            }

            string s = String.Format("{0} {1}: {2}", this._time, level, this._text);
            return s;
      
        }

    }
}
