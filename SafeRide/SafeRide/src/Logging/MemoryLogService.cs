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

        public List<LogMessage> LogList
        {
            get { return _logList; }
        }

        public MemoryLogService()
        {
            _logList = new List<LogMessage>();
        }

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
