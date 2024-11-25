
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
        private List<Course> TotalCourses { get; set; } = [];

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
                    if(preferredCourse == CoursePreferences[i].course)
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
        public CourseAndPreference GetCourseAndPreference(Course QuerryCourse)
        {
            //if (!TotalCourses.Contains(QuerryCourse))
            //{
            //    AddCoursePreference(QuerryCourse, 3); // 3 = default preference.
            //}
            CourseAndPreference Answer = CoursePreferences[0];
            for (int i = 0; i < CoursePreferences.Count; i++) 
            {
                if (CoursePreferences[i].course == QuerryCourse)
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

            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)
            {
                int random = new Random().Next();
                Course tempCourse = InitializeData.ListOfCourses[i];
                Professor tempProf = InitializeData.ListOfProfessors[random % InitializeData.ListOfProfessors.Count];
                CourseProfessor tempCourseProf = new CourseProfessor(tempCourse, tempProf );
                assignedList.Add(tempCourseProf);
                tempProf.AddAssignedCourse(tempCourse);

            }


            //for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)
            //{
            //    Course disCourse = InitializeData.ListOfCourses[i];
            //    Professor assignedProf = InitializeData.ListOfProfessors[0];
            //    for (int j = 0; j < InitializeData.ListOfProfessors.Count; j++)
            //    {
            //        if (InitializeData.ListOfProfessors[j].GetCourseAndPreference(disCourse).preference > assignedProf.GetCourseAndPreference(disCourse).preference)
            //        {
            //            assignedProf = InitializeData.ListOfProfessors[j];
            //        }
            //    }
            //    CourseProfessor AssignedCourseProf = new CourseProfessor(disCourse, assignedProf);
            //    assignedList.Add(AssignedCourseProf);

            //}
            //for (int i = 0; i < assignedList.Count; i++)
            //{
            //    assignedList[i].professor.AddAssignedCourse(assignedList[i].course);
            //}
            return assignedList;
        }
        
       
    }
}
