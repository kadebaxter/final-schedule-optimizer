using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    public class CourseAndPreference
    {
        public CourseAndPreference(Course daCourse, int daPreference)
        {
            course = daCourse;
            preference = daPreference;
        }
        public Course course { get; set; }
        public int preference { get; set; }
    }
}
