using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using System.Data.SqlClient;

namespace SafeRide.src.DataAccess
{
    public class LogMessageSQLServerDAO : ILogMessageDAO
    {
        private SqlConnection _conn;
        
        public LogMessageSQLServerDAO()
        {

        }
        
        public int Create(LogMessage message)
        {
            return null;
        }

        public List<LogMessage> GetByLevel(Level level)
        {
            return null;
        }

        public List<LogMessage> GetByTimeRange(DateTime start, DateTime end)
        {
            return null;
        }

        public int DeleteByLevel(Level level)
        {
            return null;
        }

        public int DeleteByTimeRange(DateTime start, DateTime end)
        {
            return null;
        }

        public List<LogMessage> GetAllLogs()
        {
            return null;
        }
    }
}
