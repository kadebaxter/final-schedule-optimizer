using ScheduleOptimizer.Logic;
using System.Security.Cryptography.X509Certificates;

namespace ScheduleOptimizer.Tests;

public class UnitTest1
{
    [Fact]
    public void ProfessorPreference()
    {
        Class1 newclass = new Class1();
        int y = 2;
        Assert.NotEqual(y, newclass.x);
    }

    public void Test2()
    {
        Scheduling class2 = new Scheduling();
        int x = 4;
        Assert.NotEqual(x, class2.y);
    }
}