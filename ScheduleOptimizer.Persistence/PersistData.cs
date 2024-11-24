using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ScheduleOptimizer.Persistence
{
    public static class PersistData
    {
        public static List<string> BuildProfessorList()
        {
            List<string> professorNames = ["Bob", "John", "Craig", "Garth", "Heber"];
            return professorNames;
        }
        public static List<(string, int)> BuildCourseList()
        {
            List<(string, int)> courseNamesIds = [("IntroSE", 1574), ("Computer Organization and Architecture", 3374), ("Statistics for Scientists and Engineers", 3375),
                ("Discrete Math", 2555), ("Biology 1610", 2303), ("English 1010", 2252)];

            return courseNamesIds;
        }

        public static List<(int, RoomType)> BuildRoomList()
        {
            List<(int, RoomType)> roomNums = [(123, RoomType.Normal), (124, RoomType.Normal),
                (125, RoomType.Normal), (126, RoomType.Normal), (12999, RoomType.Lab)];
            return roomNums;
        }

        //string for room type = "lab", "normal", or "online"
        public static string[] ReadInRooms()
        {
            string[] rooms = File.ReadAllLines(FindFile("rooms.txt"));
            return rooms;
        }

        public static string[] ReadInCourses()
        {
            string[] courses = File.ReadAllLines(FindFile("courses.txt"));
            return courses;
        }

        public static string[] ReadInProfessors()
        {
            string[] professors = File.ReadAllLines(FindFile("professors.txt"));
            return professors;
        }

        public static string[] ReadInSchedules()
        {
            string[] schedules = File.ReadAllLines(FindFile("schedules.txt"));
            return schedules;
        }

        public static void WriteAllToFile(string rooms, string courses, string professors, string schedules)
        {
            File.WriteAllText(FindFile("rooms.txt"), rooms);
            File.WriteAllText(FindFile("courses.txt"), courses);
            File.WriteAllText(FindFile("professors.txt"), professors);
            File.WriteAllText(FindFile("schedules.txt"), schedules);
        }

        public static string FindFile(string fileName)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (true)
            {
                var testPath = Path.Combine(directory.FullName, fileName);
                if (File.Exists(testPath))
                {
                    return testPath;
                }

                if (directory.FullName == directory.Root.FullName)
                {
                    throw new FileNotFoundException($"I looked for {fileName} in every folder from {Directory.GetCurrentDirectory()} to {directory.Root.FullName} and couldn't find it.");
                }
                directory = directory.Parent;
            }
        }

    }
}

