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
        WeekDay weekDay;
        DateTime time;

        public AvailableTimes(WeekDay day, DateTime classTime)
        {
            weekDay = day;
            time = classTime;
        }
    }
}
