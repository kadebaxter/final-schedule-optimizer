using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }

    public Course(int courseId, string courseName, string description)
    {
        CourseId = courseId;
        CourseName = courseName;
        Description = description;
    }
n
    public void DisplayCourseInfo()
    {
        Console.WriteLine($"Course ID: {CourseId}");
        Console.WriteLine($"Course Name: {CourseName}");
        Console.WriteLine($"Description: {Description}");
    }
}