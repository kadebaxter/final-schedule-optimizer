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

        private List<AvailableTimes> SetTimes(List<int> times)
        {
            List<AvailableTimes> timesToReturn = new();
            foreach (int time in times)
            {
                foreach (WeekDay day in _weekDays)
                {
                    if (time.ToString().Count() == 3)
                    {
                        timesToReturn.Add(new(new(new(2024, 12, (int)day), TimeOnly.Parse(time.ToString().Insert(1, ":").Insert(4, ":00")))));
                    }
                    else
                    {
                        timesToReturn.Add(new(new(new(2024, 12, (int)day), TimeOnly.Parse(time.ToString().Insert(2, ":").Insert(5, ":00")))));

                    }
                }
            }
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

        public Dictionary<(DateTime, Course), ScheduledCourse> GenerateSchedule(List<CourseRoom> courseRooms, List<CourseProfessor> professorCourses)
        {
            Dictionary<(DateTime, Course), ScheduledCourse> scheduledCourseList = new();
            _availableTimes = SetTimes([730, 830, 930, 1030, 1130, 1230, 130, 230, 330, 430]);
            Random random = new Random();
            for (int i = 0; i < courseRooms.Count(); i++)
            {
                int randomNumber = random.Next(0, _availableTimes.Count() - 1);

                scheduledCourseList.Add((_availableTimes[randomNumber].date, courseRooms[i].Course),
                    new(courseRooms[i].Course,
                    ReturnProfessorGivenName(courseRooms[i].Course.CourseName, professorCourses),
                    courseRooms[i].Rooms[random.Next(0, courseRooms[i].Rooms.Count() - 1)], _availableTimes[randomNumber].date));
            }
            return scheduledCourseList;
        }
    }
}
