using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Logging
{
    public class MemoryLogService : ILogService
    {
        private List<LogMessage> _logList;

        public bool Write(LogMessage message)
        {
            return null;
        }
    }
}
