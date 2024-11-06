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
        private List<(Course, Enum)> listofPreference;
        public Professor(List<(Course,Enum)> courseList)
        {
            listofPreference = courseList; 

        }
        
    public static List<(Course,Professor)> CalculatePreferences()
        {
            // Calculate professor preference and return a list of course and the optimum professor
            return new List<(Course, Professor)> ();
        }



    }
}
