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

    public static CourseTimes ParseCourseTimes(string courseTime)
    {
        switch (courseTime)
        {
            case "MWF730":
                return CourseTimes.MWF730;
            case "MWF830":
                return CourseTimes.MWF830;
            case "MWF930":
                return CourseTimes.MWF930;
            case "MWF1030":
                return CourseTimes.MWF1030;
            case "MWF1130":
                return CourseTimes.MWF1130;
            case "MWF1230":
                return CourseTimes.MWF1230;
            case "MWF130":
                return CourseTimes.MWF130;
            case "MWF230":
                return CourseTimes.MWF230;
            case "MWF330":
                return CourseTimes.MWF330;
            case "MWF430":
                return CourseTimes.MWF430;
            case "TTh730":
                return CourseTimes.TTh730;
            case "TTh930":
                return CourseTimes.TTh930;
            case "TTh1130":
                return CourseTimes.TTh1130;
            case "TTh130":
                return CourseTimes.TTh130;
            case "TTh330":
                return CourseTimes.TTh330;
            default:
                throw new Exception("Didn't have the correct room type in file input.");
        }
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
        Professor professor = new(s);
        return professor;
    }

    //sb.AppendLine($"{scheduledCourse.professor.Name},{scheduledCourse.course.CourseName},{scheduledCourse.course.CourseId}," +
    //            $"{scheduledCourse.course.NeedsLab},{scheduledCourse.room.RoomNumber},{scheduledCourse.room.RoomType.ToString()},{scheduledCourse.date.ToString()}")
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
        return new(schCrs, schCrsPro, schRm, ParseCourseTimes(parts[6]));
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
            sb.AppendLine($"{professor.Name}");
        }
        return sb.ToString();
    }

    private static string SchedulesToText(List<ScheduledCourse> listOfScheduledCourses)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var scheduledCourse in listOfScheduledCourses)
        {
            sb.AppendLine($"{scheduledCourse.professor.Name},{scheduledCourse.course.CourseName},{scheduledCourse.course.CourseId}," +
                $"{scheduledCourse.course.NeedsLab},{scheduledCourse.room.RoomNumber},{scheduledCourse.room.RoomType.ToString().ToLower()},{scheduledCourse.date.ToString()}");
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

