using ScheduleOptimizer.Logic;

namespace ScheduleOptimizer.Tests;

public class SchedulingTests
{
    [Fact]
    public void DetectCourseCollision()
    {
        //Arrange
        Course course1 = new(123, "Math");
        Course course2 = new(234, "Science");
        Room room1 = new(1, Persistence.RoomType.Normal);
        Room room2 = new(2, Persistence.RoomType.Normal);
        Professor professor1 = new("Bob");
        Professor professor2 = new("Bill");
        CourseRoom cr1 = new(course1, [room1, room2]);
        CourseRoom cr2 = new(course2, [room1, room2]);
        CourseProfessor pc1 = new(course1, professor1);
        CourseProfessor pc2 = new(course2, professor2);
        List<CourseRoom> courses = [cr1, cr2];
        List<Course> courseList = [course1, course2];
        List<CourseProfessor> professors = [pc1, pc2];
        List<DateTime> dates = [DateTime.Parse("5:45:00 pm"), DateTime.Parse("5:46:00 pm")];
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);
        

        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);
        Assert.NotEqual(scheduleList[(dates[0], course1)].professor, scheduleList[(dates[1], course2)].professor);
    }

    [Fact]
    public void DetectProfessorCollision()
    {
        Course course1 = new(123, "Math");
        Course course2 = new(234, "Science");
        Room room1 = new(1, Persistence.RoomType.Normal);
        Room room2 = new(2, Persistence.RoomType.Normal);
        Professor professor1 = new("Bob");
        Professor professor2 = new("Bill");
        CourseRoom cr1 = new(course1, [room1, room2]);
        CourseRoom cr2 = new(course2, [room1, room2]);
        CourseProfessor pc1 = new(course1, professor1);
        CourseProfessor pc2 = new(course2, professor2);
        List<CourseRoom> courses = [cr1, cr2];
        List<Course> courseList = [course1, course2];
        List<CourseProfessor> professors = [pc1, pc2];
        List<DateTime> dates = [DateTime.Parse("5:45:00 pm"), DateTime.Parse("5:46:00 pm")];
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);

        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);

        Assert.NotEqual(scheduleList[(dates[0], course1)].professor, scheduleList[(dates[1], course2)].professor);
    }
    [Fact]
    public void DetectRoomCollision()
    {
        Course course1 = new(123, "Math");
        Course course2 = new(234, "Science");
        Room room1 = new(1, Persistence.RoomType.Normal);
        Room room2 = new(2, Persistence.RoomType.Normal);
        Professor professor1 = new("Bob");
        Professor professor2 = new("Bill");
        CourseRoom cr1 = new(course1, [room1, room2]);
        CourseRoom cr2 = new(course2, [room1, room2]);
        CourseProfessor pc1 = new(course1, professor1);
        CourseProfessor pc2 = new(course2, professor2);
        List<CourseRoom> courses = [cr1, cr2];
        List<Course> courseList = [course1, course2];
        List<CourseProfessor> professors = [pc1, pc2];
        List<DateTime> dates = [DateTime.Parse("5:45:00 pm"), DateTime.Parse("5:46:00 pm")];
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);

        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);

        Assert.NotEqual(scheduleList[(dates[0], course1)].professor, scheduleList[(dates[1], course2)].professor);
    }
}