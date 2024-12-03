using ScheduleOptimizer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    public class AvailableTimes
    {
        public readonly CourseDays day;
        public readonly int time;

        public AvailableTimes(CourseDays day, int time)
        {
            this.time = time;
            this.day = day;
        }
    }
}
