using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface ILogMessageDAO
    {
        public int Create(LogMessage message);

        public List<LogMessage> GetByLevel(Level level);

        public List<LogMessage> GetByTimeRange(DateTime start, DateTime end);

        public int DeleteByLevel(Level level);

        public int DeleteByTimeRange(DateTime start, DateTime end);

        public List<LogMessage> GetAllLogs();

    }
}
