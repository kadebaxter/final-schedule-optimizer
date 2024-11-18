using ScheduleOptimizer.Logic;

public class CourseRoom
{
    public Course Course { get; set; }
    public List<Room> Rooms { get; set; }
    public CourseRoom(Course course, List<Room> rooms)
    {
        Course = course;
        Rooms = rooms;

    }

   
}  
