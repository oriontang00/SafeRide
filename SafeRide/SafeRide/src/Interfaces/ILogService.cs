using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    interface ILogService
    {
        public bool Write(LogMessage message);
    }
}
