using ScheduleOptimizer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    internal class AvailableTimes
    {
        public readonly DateTime date;

        public AvailableTimes(DateTime classTime)
        {
            
            date = classTime;
        }
    }
}
