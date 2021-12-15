﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    public enum Level
    {
        Debug,
        Information,
        Warn,
        Error,
        Fatal
    };

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

        public LogMessage(string text, Level level)
        {
            this._text = text;
            this._logLevel = level;
            this._time = DateTime.Now;
        }

        public LogMessage(string text, Level level, DateTime time)
        {
            this._text = text;
            this._logLevel = level;
            this._time = time;
        }

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