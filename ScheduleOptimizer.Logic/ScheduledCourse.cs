using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    public class ScheduledCourse
    {
        readonly Course course;
        readonly Professor professor;
        readonly Room room;
        readonly DateTime date;

        public ScheduledCourse(Course course, Professor professor, Room room, DateTime date)
        {
            this.course = course;
            this.professor = professor;
            this.room = room;
            this.date = date;
        }
    }
}
