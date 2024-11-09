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

    public static void BeginData()
    {
        AddProfessors();
        AddCourses();
        AddRooms();
    }

    public static void ClearData()
    {
        ListOfProfessors.Clear();
        ListOfCourses.Clear();
        ListOfRooms.Clear();
    }
    private static void AddProfessors()
    {
        foreach(string name in PersistData.BuildProfessorList())
        {
            ListOfProfessors.Add(new(name));
        }
    }

    private static void AddCourses()
    {
        foreach((string, int) course in PersistData.BuildCourseList())
        {
            ListOfCourses.Add(new(course.Item2, course.Item1));
        }
    }

    private static void AddRooms()
    {
        foreach((int, RoomType) rmNum in PersistData.BuildRoomList())
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

                tempProf.AddCoursePreference(ListOfCourses[i], pref);
            }
        }
    }
}

