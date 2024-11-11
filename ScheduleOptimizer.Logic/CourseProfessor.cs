using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOptimizer.Logic
{
    public class CourseProfessor
    {
        public CourseProfessor(Course daCourse, Professor daProfessor) 
        {      
            professor = daProfessor;
            course = daCourse;
        }

        public Professor professor { get; set; }
        public Course course { get; set; }
    }
}
