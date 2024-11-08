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
    public void ProfessorPreference()
    {
        Professor testProf = new Professor("TestProf");
        Course testCourse = new Course(1410, "Intro to Programming");
        Persistence1 testPersistence = new Persistence1();
        
        testProf.AddCoursePreference(testCourse, testPersistence.Preference.Favored);
    }
}