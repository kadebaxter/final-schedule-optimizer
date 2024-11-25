using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleOptimizer.Persistence;

namespace ScheduleOptimizer.Logic;

public static class InitializeData
{
    public static List<Professor> ListOfProfessors = [];
    public static List<Course> ListOfCourses = [];
    public static List<Room> ListOfRooms = [];
    public static List<ScheduledCourse> ListOfScheduledCourses = [];
    // should I build a list for CourseAndPreference and CourseProfessor?

    public static void BeginData()
    {
        //ListOfProfessors =
        FillProfessorList(PersistData.ReadInProfessors());
        //ListOfCourses = 
        FillCourseList(PersistData.ReadInCourses());
        //ListOfRooms =
        FillRoomList(PersistData.ReadInRooms());
        FillScheduledCourseList(PersistData.ReadInSchedules());
        BuildProfessorPreference();
    }

    public static void ClearData()
    {
        ListOfProfessors.Clear();
        ListOfCourses.Clear();
        ListOfRooms.Clear();
        ListOfScheduledCourses.Clear();
    }

    private static void FillRoomList(string[] strings)
    {
        foreach (string s in strings)
        {
            ListOfRooms.Add(ParseRoom(s));
        }
    }

    private static void FillCourseList(string[] strings)
    {
        foreach (string s in strings)
        {
            ListOfCourses.Add(ParseCourse(s));
        }
    }

    private static void FillProfessorList(string[] strings)
    {
        foreach (string s in strings)
        {
            ListOfProfessors.Add(ParseProfessor(s));
        }
    }

    private static void FillScheduledCourseList(string[] strings)
    {
        foreach (string s in strings)
        {
            ListOfScheduledCourses.Add(ParseScheduledCourse(s));
        }
    }

    private static Room ParseRoom(string s)
    {
        string[] parts = s.Split(',');
        int roomNumber = int.Parse(parts[0]);
        switch (parts[1])
        {
            case "normal":
                return new(roomNumber, RoomType.Normal);
            case "lab":
                return new(roomNumber, RoomType.Lab);
            case "online":
                return new(roomNumber, RoomType.Online);
            default:
                throw new Exception("Didn't have the correct room type in file input.");
        }
    }

    private static Course ParseCourse(string s)
    {
        string[] parts = s.Split(',');
        string courseName = parts[0];
        int courseID = int.Parse(parts[1]);
        return new(courseID,  courseName);
    }

    private static Professor ParseProfessor(string s)
    {
        Professor professor = new(s);
        return professor;
    }

    private static ScheduledCourse ParseScheduledCourse(string s)
    {
        throw new NotImplementedException();
    }
    private static void AddProfessors()
    {
        foreach (string name in PersistData.BuildProfessorList())
        {
            ListOfProfessors.Add(new(name));
        }
    }

    private static void AddCourses()
    {
        foreach ((string, int) course in PersistData.BuildCourseList())
        {
            ListOfCourses.Add(new(course.Item2, course.Item1));
        }
    }

    private static void AddRooms()
    {
        foreach ((int, RoomType) rmNum in PersistData.BuildRoomList())
        {
            ListOfRooms.Add(new(rmNum.Item1, rmNum.Item2));
        }
    }

    public static void BuildProfessorPreference()
    {
        for (int i = 0; i < ListOfProfessors.Count; i++)
        {
            Professor tempProf = ListOfProfessors[i];
            for (int j = 0; j < ListOfCourses.Count; j++)
            {
                int pref = new Random().Next() % 4;
                //int pref = 3;// this used to be random, but I couldn't be sure it was correct. 

                tempProf.AddCoursePreference(ListOfCourses[i], pref);
            }
        }
    }

}

