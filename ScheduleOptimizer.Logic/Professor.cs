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
        //public string Address { get; set; }   // I don't see how address is necesary.
        public List<(Course, Enum)> CoursePreferences { get; private set; } = [];
        public List<Course> AssignedCourses { get; private set; } = [];

        public Professor(string name)   // used to take in a string named address and I don't think it's necessary
        {
            Name = name;
            //  Address = address;    // I don't know why we would need an address
        }

        public void AddCoursePreference(Course preferredCourse, Enum preferredRating)
        {

            if (!CoursePreferences.Contains((preferredCourse, preferredRating)))
            {
                CoursePreferences.Add((preferredCourse, preferredRating));
                // Console.WriteLine($"Course {preferredCourse.CourseName} added to preferences for {Name}.");
            }
            else
            {
                throw new Exception();
            }
        }

        //public void AssignCourse(Course courseToAssign)
        //{
        //    if (CoursePreferences.Contains(courseToAssign) && !AssignedCourses.Contains(courseToAssign))
        //    {
        //        AssignedCourses.Add(courseToAssign);
        //        Console.WriteLine($"Course {courseToAssign.CourseName} assigned to {Name}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Course {courseToAssign.CourseName} cannot be assigned to {Name}. Check preferences or existing assignments.");
        //    }
        //}
    }
}
