using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCourse.OwnProgram
{
    public class ParentClass
    {
        public void ParentMethod()
        {
            Console.WriteLine("This is from Parent Class - Called using inheritance and object");
        }

        public static void ParentStaticMethod()
        {
            Console.WriteLine("This is from Parent Class Static - Called using inheritance and without object");
        }
    }
}
