using ScheduleOptimizer.Logic;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Tests
{
    public class ProfessorPreferenceTests
    {
        //Before making a test make sure to initialize the data in the following way
        //InitializeData.BeginData();
        //Then clear after the test is over
        //InitializeData.ClearData()
        [Fact]
        public void TestProfessorPreference()
        {
            InitializeData.BeginData();
            // roomNums list
            // CourseNamesID list
            // ProfessorNames

            // tests that the preference we just added is the same as the preference we just added. A fairly redundant test for sure :)
            Professor testProf = InitializeData.ListOfProfessors[0];
            Course testCourse = new Course(12345, "testCourse");
            InitializeData.ListOfCourses.Add(testCourse);

            // proof that testProf.AddCoursePreference doesn't add a new course after AddCoursePreference
            int lengthOfCourseList = InitializeData.ListOfCourses.Count;
            testProf.AddCoursePreference(InitializeData.ListOfCourses[0], 5);
            CourseAndPreference rating = testProf.GetCourseAndPreference(InitializeData.ListOfCourses[0]);
            Assert.Equal(lengthOfCourseList, InitializeData.ListOfCourses.Count);

            // this tests if the remove actually worked
            InitializeData.ListOfCourses.Remove(testCourse);
            Assert.Equal(lengthOfCourseList-1, InitializeData.ListOfCourses.Count);

            Assert.Equal(5, rating.preference);
            //Assert.True(InitializeData.ListOfProfessors.Contains(testProf));// I don't trust the .Contains() method
            Assert.True(InitializeData.ListOfCourses.Contains(testCourse));


            List<CourseProfessor> assignedList = InitializeData.ListOfProfessors[0].CalculateCourseProfessor();   // THIS LINE KILLS EVERYTHING
            Assert.Equal(testProf, assignedList[0].professor);
           
            // IMPORTANT: // make sure that there is a professor attatched to a course!

            InitializeData.ClearData(); // Clear the data for the next test.
        }
    }
}
