using ScheduleOptimizer.Logic;

namespace ScheduleOptimizer.Tests;

public class SchedulingTests
{
    [Fact]
    public void DetectCourseCollision()
    {
        //Arrange
        InitializeData.BeginData();
        List<Course> courseList = InitializeData.ListOfCourses;
        CourseRoom cr1 = new(courseList[0], InitializeData.ListOfRooms);
        CourseRoom cr2 = new(courseList[1], InitializeData.ListOfRooms);
        List<CourseRoom> courses = [cr1, cr2];
        List<Professor> professorList = InitializeData.ListOfProfessors;
        CourseProfessor pc1 = new(courseList[0], professorList[0]);
        CourseProfessor pc2 = new(courseList[1], professorList[1]);
        List<CourseProfessor> professors = [pc1, pc2];

        //Act
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);
        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);
        var keys = scheduleList.Keys.ToList();

        //Assert
        Assert.NotEqual(scheduleList[keys[0]].course.CourseName, scheduleList[keys[1]].course.CourseName);
        InitializeData.ClearData();
    }

    [Fact]
    public void DetectProfessorCollision()
    {
        //Arrange
        InitializeData.BeginData();
        List<Course> courseList = InitializeData.ListOfCourses;
        CourseRoom cr1 = new(courseList[0], InitializeData.ListOfRooms);
        CourseRoom cr2 = new(courseList[1], InitializeData.ListOfRooms);
        List<CourseRoom> courses = [cr1, cr2];
        List<Professor> professorList = InitializeData.ListOfProfessors;
        CourseProfessor pc1 = new(courseList[0], professorList[0]);
        CourseProfessor pc2 = new(courseList[1], professorList[1]);
        List<CourseProfessor> professors = [pc1, pc2];

        //Act
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);
        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);
        var keys = scheduleList.Keys.ToList();

        //Assert
        Assert.NotEqual(scheduleList[keys[0]].professor.Name, scheduleList[keys[1]].professor.Name);
        InitializeData.ClearData();
    }
    [Fact]
    public void DetectRoomCollision()
    {
        //Arrange
        InitializeData.BeginData();
        List<Course> courseList = InitializeData.ListOfCourses;
        CourseRoom cr1 = new(courseList[0], InitializeData.ListOfRooms);
        CourseRoom cr2 = new(courseList[1], InitializeData.ListOfRooms);
        List<CourseRoom> courses = [cr1, cr2];
        List<Professor> professorList = InitializeData.ListOfProfessors;
        CourseProfessor pc1 = new(courseList[0], professorList[0]);
        CourseProfessor pc2 = new(courseList[1], professorList[1]);
        List<CourseProfessor> professors = [pc1, pc2];

        //Act
        Scheduling schedule = new(Persistence.Semester.Spring, 2, courseList);
        Dictionary<(DateTime, Course), ScheduledCourse> scheduleList = schedule.GenerateSchedule(courses, professors);
        var keys = scheduleList.Keys.ToList();

        //Assert
        Assert.NotEqual(scheduleList[keys[0]].room.RoomNumber, scheduleList[keys[1]].room.RoomNumber);
        InitializeData.ClearData();
    }

    [Fact]
    public void CheckData()
    {
        InitializeData.BeginData();

        Assert.True(InitializeData.ListOfCourses.Count() > 0);

        InitializeData.ClearData();

        Assert.True(InitializeData.ListOfCourses.Count() == 0);
    }
}