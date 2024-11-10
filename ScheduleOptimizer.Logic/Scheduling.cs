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
        private List<AvailableTimes> _availableTimes;
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
                    _availableTimes.Add(new(day, DateTime.Parse(time.ToString("0000").Insert(2, ":").Insert(5, ":00"))));
                }
            }
        }

        public Dictionary<DateTime, ScheduledCourse> GenerateSchedule(List<CourseRoom> courseRooms, List<ProfessorCourse> professorCourses)
        {
            throw new NotImplementedException();
        }
    }

    public class CourseRoom
    {
        public Course Course { get; set; }
        public Room Room { get; set; }
        public CourseRoom(Course course,  Room room)
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
