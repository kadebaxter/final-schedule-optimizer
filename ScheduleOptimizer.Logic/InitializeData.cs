using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleOptimizer.Persistence;

namespace ScheduleOptimizer.Logic;

internal class InitializeData
{
    public List<Professor> ListOfProfessors = [];
    public List<Course> ListOfCourses = [];
    public List<Room> ListOfRooms = [];

    public void BeginData()
    {
        AddProfessors();
        AddCourses();
        AddRooms();
    }

    private void AddProfessors()
    {
        foreach(string name in PersistData.BuildProfessorList())
        {
            ListOfProfessors.Add(new(name));
        }
    }

    private void AddCourses()
    {
        foreach((string, int) course in PersistData.BuildCourseList())
        {
            ListOfCourses.Add(new(course.Item2, course.Item1));
        }
    }

    private void AddRooms()
    {
        foreach((int, RoomType) rmNum in PersistData.BuildRoomList())
        {
            ListOfRooms.Add(new(rmNum.Item1, rmNum.Item2));
        }
    }

    public void BuildProfessorPreference()
    {
        for (int i = 0; i < ListOfProfessors.Count; i++)
        {
            Professor tempProf = ListOfProfessors[i];
            for (int j = 0; j < ListOfCourses.Count; j++)
            {
                int pref = new Random().Next() % 4;

                tempProf.AddCoursePreference(ListOfCourses[i], (Preference)pref);
            }
        }
    }
}

