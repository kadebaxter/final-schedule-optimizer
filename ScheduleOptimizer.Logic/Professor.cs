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
        public string Address { get; set; }
        public List<Course> CoursePreferences { get; private set; } = new List<Course>();
        public List<Course> AssignedCourses { get; private set; } = new List<Course>();

        public Professor(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddCoursePreference(Course preferredCourse)
        {

            if (!CoursePreferences.Contains(preferredCourse))
            {
                CoursePreferences.Add(preferredCourse);
                Console.WriteLine($"Course {preferredCourse.CourseName} added to preferences for {Name}.");
            }
        }

        public void AssignCourse(Course courseToAssign)
        {
            if (CoursePreferences.Contains(courseToAssign) && !AssignedCourses.Contains(courseToAssign))
            {
                AssignedCourses.Add(courseToAssign);
                Console.WriteLine($"Course {courseToAssign.CourseName} assigned to {Name}.");
            }
            else
            {
                Console.WriteLine($"Course {courseToAssign.CourseName} cannot be assigned to {Name}. Check preferences or existing assignments.");
            }
        }
    }
