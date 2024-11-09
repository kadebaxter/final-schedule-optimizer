
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    

    public class Professor
    {
        public string Name { get; set; }
        public List<CourseAndPreference> CoursePreferences { get; private set; } = [];
        public List<Course> AssignedCourses { get; private set; } = [];

        public Professor(string name)   
        {
            Name = name;
        }
        public void AddCoursePreference(Course preferredCourse, int preferredRating)
        {
            CourseAndPreference addingCourse = new CourseAndPreference(preferredCourse, preferredRating);   
            CoursePreferences.Add(addingCourse);
        }

        // Takes in a course and returns that course with the Professor's preference of it.
        public CourseAndPreference GetCourseAndPreference(Course QuerryCourse)
        {
            CourseAndPreference Answer = null;
            for (int i = 0; i < CoursePreferences.Count; i++) 
            {
                if (CoursePreferences[i].course == QuerryCourse)
                { 
                    Answer = CoursePreferences[i];
                }  
            }
            if (Answer == null)
            {
                throw new Exception();
            }
            return Answer;
        }

        
    }
}
