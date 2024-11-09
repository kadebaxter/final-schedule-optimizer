using ScheduleOptimizer.Logic;
using ScheduleOptimizer.Persistence;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ScheduleOptimizer.Tests;

public class UnitTest1
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
        

        InitializeData.ClearData(); // Clear the data for the next test.
    }
}