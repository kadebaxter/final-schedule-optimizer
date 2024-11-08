using ScheduleOptimizer.Logic;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ScheduleOptimizer.Persistence;

public class Persistence
{
    public List<Professor> ListOfProfessors = new List<Logic.Professor>();
    public List<Course> ListOfCourses = new List<Logic.Course>();
    public List<Room> ListOfRooms = new List<Room>();


    public void BuildProfessorList()
    {
        Professor Bob = new Professor("Bob");
        Professor John = new Professor("John");
        Professor Craig = new Professor("Craig");
        Professor Garth = new Professor("Garth");
        Professor Heber = new Professor("Heber");

        ListOfProfessors.Add(Bob);
        ListOfProfessors.Add(John);
        ListOfProfessors.Add(Craig);
        ListOfProfessors.Add(Garth);
        ListOfProfessors.Add(Heber);
    }
    public void BuildCourseList()
    {
        Course IntroSE = new Course("IntroSE");
        Course OrgArchitecture = new Course("Computer Organization and Architecture");
        Course StatsSciEngineers = new Course("Statistics for Scientists and Engineers");
        Course DiscreteMath = new Course("Discrete Math");
        Course Biology = new Course("Biology 1610");
        Course English1010 = new Course("English 1010");

        ListOfCourses.Add(IntroSE);
        ListOfCourses.Add(OrgArchitecture);
        ListOfCourses.Add(StatsSciEngineers);
        ListOfCourses.Add(Biology);
        ListOfCourses.Add(English1010);
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

      
    public void BuildRoomList()
    { 
        Room grsc123 = new Room(123, "normal");
        Room grsc124 = new Room(124, "normal");
        Room grsc125 = new Room(125, "normal");
        Room grsc126 = new Room(126, "online");
        Room grscLab1 = new Room(12999, "lab");

        ListOfRooms.Add(grsc123);
        ListOfRooms.Add(grsc124);
        ListOfRooms.Add(grsc125);
        ListOfRooms.Add(grsc126);
        ListOfRooms.Add(grscLab1);

    }

    //string for room type = "lab", "normal", or "online"

    private enum Preference
    {
        pleaseNo,   // 0
        NotFavored, // 1
        Neutral,    // 2
        Favored,    // 3
    }
}


