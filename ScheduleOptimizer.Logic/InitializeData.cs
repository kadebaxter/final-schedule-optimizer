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
        FillCourseList(PersistData.ReadInCourses());
        FillProfessorList(PersistData.ReadInProfessors());
        //ListOfCourses = 
        //ListOfRooms =
        FillRoomList(PersistData.ReadInRooms());
        FillScheduledCourseList(PersistData.ReadInSchedules());
        //BuildProfessorPreference();
    }

    public static void ClearData()
    {
        ListOfProfessors.Clear();
        ListOfCourses.Clear();
        ListOfRooms.Clear();
        ListOfScheduledCourses.Clear();
    }

    public static void SaveData()
    {
        PersistData.WriteAllToFile(RoomsToText(ListOfRooms), CoursesToText(ListOfCourses), ProfessorsToText(ListOfProfessors), SchedulesToText(ListOfScheduledCourses));
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
            var course = ParseCourse(s);
            if (!ListOfCourses.Any(c => c.CourseId == course.CourseId))
            {
                ListOfCourses.Add(course);
            }
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

    public static RoomType ParseRoomType(string roomType)
    {
        switch (roomType)
        {
            case "normal":
                return RoomType.Normal;
            case "lab":
                return RoomType.Lab;
            case "online":
                return RoomType.Online;
            default:
                throw new Exception("Didn't have the correct room type in file input.");
        }
    }

    public static CourseDays ParseCourseTimes(string courseTime)
    {
        switch (courseTime)
        {
            case "MWF":
                return CourseDays.MWF;
            case "TTh":
                return CourseDays.TTh;
            default:
                throw new Exception("Didn't have the correct room type in file input.");
        }
    }

    private static Course FindCourseGivenName(string courseName)
    {
        Course prfCrs = null;
        foreach (var course in ListOfCourses)
        {
            if (course.CourseName == courseName)
                prfCrs = course;
        }
        return prfCrs;
    }

    private static Room ParseRoom(string s)
    {
        string[] parts = s.Split(',');
        int roomNumber = int.Parse(parts[0]);
        return new(roomNumber, ParseRoomType(parts[1]));
    }

    private static Course ParseCourse(string s)
    {
        string[] parts = s.Split(',');
        string courseName = parts[0];
        int courseID = int.Parse(parts[1]);
        bool needLab = bool.Parse(parts[2].ToLower());
        return new(courseID,  courseName, needLab);
    }

    private static Professor ParseProfessor(string s)
    {
        string[] parts = s.Split(",");
        Professor professor = new(parts[0]);

        Course prfCrs = new(1234567, "THIS IS WRONG");
        for (int i = 1; i < parts.Length; i++)
        {
            string[] courseParts = parts[i].Split(":");
            prfCrs = FindCourseGivenName(courseParts[0]);
            int coursePreference = int.Parse(courseParts[1]);
            professor.AddCoursePreference(prfCrs, coursePreference);
        }

        return professor;
    }

    private static ScheduledCourse ParseScheduledCourse(string s)
    {
        string[] parts = s.Split(",");
        Professor schCrsPro = new("THIS IS WRONG");
        foreach (var profe in ListOfProfessors)
        {
            if (profe.Name == parts[0])
                schCrsPro = profe;
        }

        Course schCrs = new(1234567, "THIS IS WRONG");
        foreach (var course in ListOfCourses)
        {
            if ( (course.CourseName == parts[1]) && (course.CourseId == int.Parse(parts[2])) && (course.NeedsLab == bool.Parse(parts[3])) )
                schCrs = course;
        }

        Room schRm = new(1234567, RoomType.Online);
        foreach (var room in ListOfRooms)
        {
            if ((room.RoomNumber == int.Parse(parts[4])) && (room.RoomType == ParseRoomType(parts[5])))
                schRm = room;
        }

        return new(schCrs, schCrsPro, schRm, ParseCourseTimes(parts[6]), int.Parse(parts[7]));
    }

    private static string RoomsToText(List<Room> roomsList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Room room in roomsList) 
        {
            sb.AppendLine($"{room.RoomNumber},{room.RoomType.ToString().ToLower()}");
        }
        return sb.ToString();
    }

    private static string CoursesToText(List<Course> listOfCourses)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Course course in listOfCourses)
        {
            sb.AppendLine($"{course.CourseName},{course.CourseId},{course.NeedsLab}");
        }
        return sb.ToString();
    }

    private static string ProfessorsToText(List<Professor> listOfProfessors)
    {
        StringBuilder sb = new StringBuilder();

        foreach (Professor professor in listOfProfessors)
        {
            sb.Append($"{professor.Name},");
            for (int i = 0; i < professor.CoursePreferences.Count; i++) 
            {
                if (i == professor.CoursePreferences.Count - 1)
                    sb.Append($"{professor.CoursePreferences[i].course.CourseName}:{professor.CoursePreferences[i].preference}");
                else
                    sb.Append($"{professor.CoursePreferences[i].course.CourseName}:{professor.CoursePreferences[i].preference},");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private static string SchedulesToText(List<ScheduledCourse> listOfScheduledCourses)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var scheduledCourse in listOfScheduledCourses)
        {
            sb.AppendLine($"{scheduledCourse.professor.Name},{scheduledCourse.course.CourseName},{scheduledCourse.course.CourseId}," +
                $"{scheduledCourse.course.NeedsLab},{scheduledCourse.room.RoomNumber},{scheduledCourse.room.RoomType.ToString().ToLower()},{scheduledCourse.date.ToString()},{scheduledCourse.time.ToString()}");
            //sb.AppendLine("Is this thing working");
        }
        return sb.ToString();
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

                tempProf.AddCoursePreference(ListOfCourses[j], pref);
            }
        }
    }

}

