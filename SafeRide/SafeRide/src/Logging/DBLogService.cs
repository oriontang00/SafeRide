using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Logging
{
    public class DBLogService : ILogService
    {
        private ILogMessageDAO _logMessageDAO;

        public DBLogService()
        {
            _logMessageDAO = new LogMessageSQLServerDAO();
        }

        public bool Write(LogMessage message)
        {
            return null;
        }
    } 
}
