using ScheduleOptimizer.Logic;
using System;
using System.Collections.Generic;
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
            testProf.AddCoursePreference(InitializeData.ListOfCourses[0], 5);
            CourseAndPreference rating = testProf.GetCourseAndPreference(InitializeData.ListOfCourses[0]);
            Assert.Equal(5, rating.preference);

            //DID i INITIALIZE PREFERENCE YET?

           List<CourseProfessor> assignedList = Professor.CalculateCourseProfessor();   // THIS LINE KILLS EVERYTHING
           // Assert.Equal(testProf, assignedList[0].professor);
           
            // IMPORTANT: // make sure that there is a professor attatched to a course!

            InitializeData.ClearData(); // Clear the data for the next test.
        }
    }
}
