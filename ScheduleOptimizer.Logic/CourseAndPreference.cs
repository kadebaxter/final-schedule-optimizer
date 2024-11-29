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
        public CourseAndPreference(Course disCourse)
        {
            course = disCourse;
            preference = 3; // This is a neutral preference.  1 = do not like the class. 5 = love to teach it. 
        }

        public Course course { get; set; }
        public int preference { get; set; }
    }
}
