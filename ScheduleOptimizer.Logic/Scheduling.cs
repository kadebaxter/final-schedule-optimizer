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

        private void SetTimes(List<int> times)
        {
            foreach (int time in times)
            {
                foreach (WeekDay day in _weekDays)
                {
                    if (time.ToString().Count() == 3)
                    {
                        _availableTimes.Add(new(new(new(2024, 12, (int)day), TimeOnly.Parse(time.ToString().Insert(1, ":").Insert(4, ":00")))));
                    }
                    else
                    {
                        _availableTimes.Add(new(new(new(2024, 12, (int)day), TimeOnly.Parse(time.ToString().Insert(2, ":").Insert(5, ":00")))));

                    }
                }
            }
        }

        public Dictionary<(DateTime, int), ScheduledCourse> GenerateSchedule(List<CourseRoom> courseRooms, List<ProfessorCourse> professorCourses)
        {
            Dictionary<(DateTime, int), ScheduledCourse> scheduledCourseList = new();
            SetTimes([730, 830, 930, 1030, 1130, 1230, 130, 230, 330, 430]);
            foreach (var courseRoom in courseRooms)
            {
                foreach (var courseProfessor in professorCourses)
                {
                    foreach (var time in _availableTimes)
                    {
                        scheduledCourseList.Add((time.date, courseRoom.Room.RoomNumber), new(courseRoom.Course, courseProfessor.Professor, courseRoom.Room, time.date));
                    }
                }
            }
            return scheduledCourseList;
        }
    }

    public class CourseRoom
    {
        public Course Course { get; set; }
        public Room Room { get; set; }
        public CourseRoom(Course course, Room room)
        {
            Course = course;
            Room = room;
        }
    }

    public class ProfessorCourse
    {
        public Course Course { get; set; }
        public Professor Professor { get; set; }
        public ProfessorCourse(Course course, Professor professor)
        {
            Course = course;
            Professor = professor;
        }
    }
}
