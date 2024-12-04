
using ScheduleOptimizer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{


    public class Professor
    {
        public string Name { get; set; }
        public List<CourseAndPreference> CoursePreferences { get; private set; } = [];
        public List<Course> AssignedCourses { get; private set; } = [];
        public List<Course> TotalCourses { get; set; } = [];

        public Professor(string name)
        {
            Name = name;
            // I initialize a list of all courses with a default neutral preference of int 3 each time you create a professor
            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)
            {
                CourseAndPreference tempItem = new CourseAndPreference(InitializeData.ListOfCourses[i]);
                CoursePreferences.Add(tempItem);
                Course tempCourse = InitializeData.ListOfCourses[i];
                TotalCourses.Add(tempCourse);
            }
        }
        public void AddCoursePreference(Course preferredCourse, int preferredRating)
        {
            // If someone adds a course that isn't in our list of data, it updates 3 lists. InitialiseData, CoursePreferences, and TotalCourses
            if (preferredCourse == null) 
            {
                return;
            }
            if (!TotalCourses.Contains(preferredCourse))
            {
                CourseAndPreference tempAdd = new CourseAndPreference(preferredCourse, preferredRating);
                CoursePreferences.Add(tempAdd);
                //InitializeData.ListOfCourses.Add(tempAdd.course);
                //TotalCourses.Add(preferredCourse);
            }

            // I need to initialize CourseAndPreference with Every Course
            // then search that list and update the preference;

            else
            {
                for (int i = 0; i < CoursePreferences.Count; i++)
                {
                    if (preferredCourse == CoursePreferences[i].course)
                    {
                        CoursePreferences[i].preference = preferredRating;
                    }
                }
            }
        }
        public void AddAssignedCourse(Course freshCourse)
        {
            AssignedCourses.Add(freshCourse);
        }

        // Takes in a course and returns that course with the Professor's preference of it.
        // IMPORTANT: FINDS COURSE BASED ON NAME.
        // also this method could return a null value if what you're looking for isn't found in the list :)
        public CourseAndPreference GetCourseAndPreference(Course QuerryCourse)
        {
            CourseAndPreference Answer = null;
            //CourseAndPreference Answer = CoursePreferences[0];
            for (int i = 0; i < CoursePreferences.Count; i++)
            {
                if (CoursePreferences[i].course.CourseName == QuerryCourse.CourseName)
                {
                    Answer = CoursePreferences[i];
                }
            }
            return Answer;
        }

        // assignes professors to courses based on which courses they like to teach. 
        // IMPORTANT:   this method Also fills the list in each professor class of which courses they are assigned.
        public List<CourseProfessor> CalculateCourseProfessor()
        {
            List<CourseProfessor> assignedList = new List<CourseProfessor>();
            List<Course> unassignedCourses = new List<Course>();

            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)// create list of unassigned courses
            {
                unassignedCourses.Add(InitializeData.ListOfCourses[i]);
            }

            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)// assign each course
            {
                int profIndex = i % InitializeData.ListOfProfessors.Count;// now I loop through professors evenly
                Course currentCourse = unassignedCourses[0];
                Professor currentProf = InitializeData.ListOfProfessors[profIndex];

                // find the professor's favorite course
                for (int j = 0; j < unassignedCourses.Count; j++)
                {
                    if (currentProf.GetCourseAndPreference(currentCourse) != null && currentProf.GetCourseAndPreference(unassignedCourses[j]) != null)
                    {
                        if (currentProf.GetCourseAndPreference(currentCourse).preference < currentProf.GetCourseAndPreference(unassignedCourses[j]).preference)
                        {
                            currentCourse = unassignedCourses[j];
                        }
                    }
                }
                // assign professor to the course
                assignedList.Add(new CourseProfessor(currentCourse, currentProf));
                currentProf.AssignedCourses.Add(currentCourse);
                unassignedCourses.Remove(currentCourse);
            }
            return assignedList;
        }

        // this only takes into account existing courses
        public void UpdatePreference(Course course, int preference)
        {
            Course global = null;
            bool courseFound = false;
            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)
            {
                if (InitializeData.ListOfCourses[i].CourseName == course.CourseName)
                {
                    global = InitializeData.ListOfCourses[i];
                }
            }
            for(int i = 0; i<CoursePreferences.Count; i++)
            {
                if (CoursePreferences[i].course.CourseName == course.CourseName)
                {
                    courseFound = true;
                    CoursePreferences[i].preference = preference;
                    break;
                }
            }

            // if the course doesn't exist in InitializeData.ListOfCourses 
            // I do not add/update anything
            if (!courseFound)
            {
                if(global != null)
                {
                    CoursePreferences.Add(new CourseAndPreference(course, preference));
                }
            }
        }
    }
}
