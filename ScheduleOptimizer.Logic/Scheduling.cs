using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleOptimizer.Persistence;

namespace ScheduleOptimizer.Logic
{
    public class Scheduling
    {
        private Semester _semester;
        private int _numOfClasses;
        private List<Course> _listOfCourses;
        private List<AvailableTimes> _availableTimes = new();
        private List<WeekDay> _weekDays = [WeekDay.Monday, WeekDay.Tuesday, WeekDay.Wednesday, WeekDay.Thursday, WeekDay.Friday];

        public Scheduling(Semester semester, int numOfClasses, List<Course> listOfCourses)
        {
            _semester = semester;
            _numOfClasses = numOfClasses;
            _listOfCourses = listOfCourses;
        }

        public Semester Semester { get => _semester; set => _semester = value; }
        public int NumOfClasses { get => _numOfClasses; set => _numOfClasses = value; }
        public List<Course> ListOfCourses1 { get => _listOfCourses; set => _listOfCourses = value; }

        private List<AvailableTimes> SetTimes()
        {
            List<AvailableTimes> timesToReturn = new();
            timesToReturn.Add(new(CourseDays.MWF, 730));
            timesToReturn.Add(new(CourseDays.MWF, 830));
            timesToReturn.Add(new(CourseDays.MWF, 930));
            timesToReturn.Add(new(CourseDays.MWF, 1030));
            timesToReturn.Add(new(CourseDays.MWF, 1130));
            timesToReturn.Add(new(CourseDays.MWF, 1230));
            timesToReturn.Add(new(CourseDays.MWF, 130));
            timesToReturn.Add(new(CourseDays.MWF, 230));
            timesToReturn.Add(new(CourseDays.MWF, 330));
            timesToReturn.Add(new(CourseDays.MWF, 430));
            timesToReturn.Add(new(CourseDays.TTh, 730));
            timesToReturn.Add(new(CourseDays.TTh, 930));
            timesToReturn.Add(new(CourseDays.TTh, 1130));
            timesToReturn.Add(new(CourseDays.TTh, 130));
            timesToReturn.Add(new(CourseDays.TTh, 330));

            return timesToReturn;
        }

        private static Professor ReturnProfessorGivenName(string name, List<CourseProfessor> courseProfessors)
        {
            foreach (var course in courseProfessors)
            {
                if (course.course.CourseName == name)
                {
                    return course.professor;
                }
            }
            return new($"{name} Created");
        }

        public Dictionary<(AvailableTimes, Course), ScheduledCourse> GenerateSchedule(List<CourseRoom> courseRooms, List<CourseProfessor> professorCourses)
        {
            Dictionary<(AvailableTimes, Course), ScheduledCourse> scheduledCourseList = new();
            _availableTimes = SetTimes();
            Random random = new Random();
            List<int> randomNumbersList = new();
            for (int i = 0; i < courseRooms.Count(); i++)
            {
                int newRandomNumber = random.Next(0, _availableTimes.Count() - 1);
                for (int j = 0; j < randomNumbersList.Count(); j++)
                {
                    while (randomNumbersList[j] == newRandomNumber)
                    {
                        newRandomNumber = random.Next(0, _availableTimes.Count() - 1);
                    }
                }
                randomNumbersList.Add(newRandomNumber);
                scheduledCourseList.Add((_availableTimes[newRandomNumber], courseRooms[i].Course),
                    new(courseRooms[i].Course,
                    ReturnProfessorGivenName(courseRooms[i].Course.CourseName, professorCourses),
                    courseRooms[i].Rooms[random.Next(0, courseRooms[i].Rooms.Count() - 1)], _availableTimes[newRandomNumber].day, _availableTimes[newRandomNumber].time));
            }
            return scheduledCourseList;
        }
    }
}
