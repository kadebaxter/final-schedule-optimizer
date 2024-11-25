
using ScheduleOptimizer.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            bool courseExists = false;
            // I do believe that this was was causing 
            // If someone adds a course that isn't in our list of data, it updates 3 lists. InitialiseData, CoursePreferences, and TotalCourses


            // I need to initialize CourseAndPreference with Every Course
            // then search that list and update the preference;


            for (int i = 0; i < CoursePreferences.Count; i++)
            {
                if (preferredCourse == CoursePreferences[i].course)
                {
                    CoursePreferences[i].preference = preferredRating;
                    courseExists = true;
                }
            }
            if (!courseExists)
            {
                CourseAndPreference tempAdd = new CourseAndPreference(preferredCourse, preferredRating);
                CoursePreferences.Add(tempAdd);
                InitializeData.ListOfCourses.Add(tempAdd.course);
                TotalCourses.Add(preferredCourse);
            }
        }
        public void AddAssignedCourse(Course freshCourse)
        {
            AssignedCourses.Add(freshCourse);
        }

        // Takes in a course and returns that course with the Professor's preference of it.
        public CourseAndPreference GetCourseAndPreference(Course QuerryCourse)
        {
            // this if is my problem. It keeps adding courses when it shouldn't. 
            //if (!TotalCourses.Contains(QuerryCourse))
            //{
            //    AddCoursePreference(QuerryCourse, 3); // 3 = default preference.
            //}
            CourseAndPreference Answer = CoursePreferences[0];
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
            List<Course> CourseList = new List<Course>();
            int profCounter = 0;
            CourseProfessor myCourseProfessor;


            // now I have a copy of all the courses I need to assign
            for (int i = 0; i < InitializeData.ListOfCourses.Count; i++)
            {
                CourseList.Add(InitializeData.ListOfCourses[i]);
            }

            while (CourseList.Count >= 1)
            {
                Professor tempProf = InitializeData.ListOfProfessors[profCounter];

                Course tempCourse = CourseList[0];
                for (int k = 0; k < InitializeData.ListOfCourses.Count; k++)
                {
                    if (GetCourseAndPreference(CourseList[k]).preference > GetCourseAndPreference(tempCourse).preference)
                    {
                        tempCourse = CourseList[k];
                    }
                }
                tempProf.AddAssignedCourse(tempCourse);
                CourseList.Remove(tempCourse);
                myCourseProfessor = new CourseProfessor(tempCourse, tempProf);
                assignedList.Add(myCourseProfessor);

                profCounter++;
                if (profCounter >= InitializeData.ListOfProfessors.Count) { profCounter = 0; }
            }

            return assignedList;


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
            //    CourseProfessor AssignedCourseProf = new CourseProfessor(disCourse,assignedProf);
            //    assignedList.Add(AssignedCourseProf);

            //}
            //for (int i = 0; i<assignedList.Count; i++)
            //{
            //    assignedList[i].professor.AddAssignedCourse(assignedList[i].course);
            //}
            //return assignedList;



        }
    }
}
// Calculate Course Professor
// I'll want a copy of my List TotalCourses
// copy of List Total Professors
// copy of 

// Take ListOfProfessors[i] and find his favorite course. Assign him to that course. Loop through all professors
// and strike off the courses already assigned. 
// Go one professor, GetCourseAndPreference with each course in the list, and assign him to his favorite.
// remove that course from the list and repeat with next professor. 
// Do this until ListOfCourses is empty. 