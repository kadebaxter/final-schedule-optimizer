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




    }
}

