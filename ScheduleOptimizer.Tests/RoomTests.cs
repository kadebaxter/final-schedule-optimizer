using ScheduleOptimizer.Logic;
using ScheduleOptimizer.Persistence;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ScheduleOptimizer.Tests;

public class RoomTests
{
    
    [Fact]
    public void LabRoomsAssignedCorrectly()
    {
        InitializeData.ClearData();
        InitializeData.BeginData();
        Course newCourse = new(12345, "Goated", true);
        InitializeData.ListOfCourses.Add(newCourse);
        
        List<CourseRoom> courseRooms = Course.ReturnCoursesWithRooms();
        int count = courseRooms.Count;

        Assert.NotEmpty(courseRooms);
        Assert.Equal(InitializeData.ListOfRooms[4], courseRooms[count - 1].Rooms[0]);
    }

    [Fact]
    public void NormalRoomsAssignedCorrectly()
    {

    }
}