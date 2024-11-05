using ScheduleOptimizer.Logic;
using System.Security.Cryptography.X509Certificates;

namespace ScheduleOptimizer.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Class1 newclass = new Class1();
        int y = 2;
        Assert.NotEqual(y, newclass.x);
    }
}