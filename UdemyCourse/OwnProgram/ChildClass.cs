using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCourse.OwnProgram
{
    public class ChildClass : ParentClass
    {

        public void ChildMethod()
        {
            Console.WriteLine("This is Child Class Method - Called using Object");
        }

        public static void staticMethod()
        {
            Console.WriteLine("This is Static Method - Called directly without object");
        }
        public static void Main(String[] args)
        {
            ChildClass cc = new ChildClass();
            cc.ChildMethod();

            staticMethod(); //calling static method directly without object creation
            
            ChildClass CC = new ChildClass();
            CC.ParentMethod(); //inherited method from  ParentClass

            ParentStaticMethod(); //you can call parent static method directly without object creation when inherited

        }
    }
}
