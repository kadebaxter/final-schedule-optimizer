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

    public List<CourseRoom> CourseRooms { get; private set; }
       
    public CourseRoomManager()
    {
        CourseRooms = new List<CourseRoom>();

        
        List<Course> courses = new List<Course>
        {
            new Course("intro to SE 2520 "),c
            new Course("Operating systemsc2090",),
            new Course("Data structures 2420", ),
            new Course("Digital circut 2700" , )
        };

        
        List<string> rooms = new List<string>
        {
            "Room 101",  // Regular room 
            "Room 102",  // Regular room 
            "Biology Lab", //  Lab
            "Computer Lab"  // lab
        };

        // Assign rooms to coursesw
        AssignRoomsToCourses(courses, rooms);
    }

    public List<CourseRoom> GetCourseRooms()
    {
        return CourseRooms;
    }
     
   private void ReturnCoursesWithRooms(List<Course> courses)
  
    int roomIndex = 0;
      foreach (var course in courses)
    {
      int roomNumber;
      string roomName;

      // if the course needs a lab room
      if (course.NeedsLab)
       {
        // Assign a lab room
       roomNumber = 200;  
       roomName = $"{course.CourseName} Lab";
       }
       else
        {
       // Assign a regular room
        roomNumber = 100 + roomIndex;  
        roomName = $"{course.CourseName} Room";
        }

    
    return CourseRoom.Add(new CourseRoom(course, roomNumber, roomName));
}