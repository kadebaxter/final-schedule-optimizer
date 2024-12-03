using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    public class ScheduledCourse
    {
        public readonly Course course;
        public readonly Professor professor;
        public readonly Room room;
        public readonly Persistence.CourseDays date;
        public readonly int time;

        public ScheduledCourse(Course course, Professor professor, Room room, Persistence.CourseDays date, int time)
        {
            this.course = course;
            this.professor = professor;
            this.room = room;
            this.date = date;
            this.time = time;
        }
    }
}
