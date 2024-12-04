using ScheduleOptimizer.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic;
public class Course
{
    public int CourseNumber { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public bool NeedsLab { get; set; }
    private Random random = new();

    public Course(int courseId, string courseName)
    {
        CourseId = courseId;
        CourseName = courseName;
        Description = "N/A";
    }
    public Course(int courseId, string courseName, string description)
    {
        CourseId = courseId;
        CourseName = courseName;
        Description = description;
    }

    public Course(int courseNumber, string courseName, bool needsLab)
    {
        CourseNumber = courseNumber;
        CourseId = random.Next(0, 5000);
        CourseName = courseName;
        Description = "N/A";
        NeedsLab = needsLab;
    }

    public Course(int courseNumber, int courseId, string courseName, bool needsLab)
    {
        CourseNumber = courseNumber;
        CourseId = courseId;
        CourseName = courseName;
        Description = "N/A";
        NeedsLab = needsLab;
    }

    public List<CourseRoom> CoursesWithRooms()
    {
        List<CourseRoom> courseRoomsList = new();

        int roomIndex = 0;
        foreach (var course in InitializeData.ListOfCourses)
        {
            List<Room> coursesRoomsList = new();
            foreach (var room in InitializeData.ListOfRooms)
            {
                if (course.NeedsLab && room.RoomType == Persistence.RoomType.Lab)
                {
                    coursesRoomsList.Add(room);
                }
                else if (!course.NeedsLab && room.RoomType == Persistence.RoomType.Normal)
                {
                    coursesRoomsList.Add(room);
                }
                else
                {
                    continue;
                }
            }
            courseRoomsList.Add(new(course, coursesRoomsList));
        }
        return courseRoomsList;
    }
}
