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

        public Scheduling(Semester semester, int numOfClasses, List<Course> listOfCourses)
        {
            _semester = semester;
            _numOfClasses = numOfClasses;
            _listOfCourses = listOfCourses;
        }

        public Semester Semester { get => _semester; set => _semester = value; }
        public int NumOfClasses { get => _numOfClasses; set => _numOfClasses = value; }
        public List<Course> ListOfCourses1 { get => _listOfCourses; set => _listOfCourses = value; }

        public static List<Course> MakeSchedule(List<Professor> professors, List<Course> courses, List<Room> rooms)
        {
            //This needs to schedule, based off of the professor preference, rooms, and available courses.
            throw new NotImplementedException();
            
        }
    }
}
