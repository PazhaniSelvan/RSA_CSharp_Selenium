using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UdemyCourse.OwnProgram
{
    public class DataTypes
    {




        static void Main(string[] args)
        {
            Console.WriteLine("Executing from OwnProgram class");
            //Static Data Types
            //Int,Double,String
            int i = 10;
            Double d = 10.11;
            String s = "C# Selenium";

            Console.WriteLine(i + d + s);

            //concat
            Console.WriteLine("Value of i: "+i);
            Console.WriteLine($"Value of i: {i}");

            Console.WriteLine("Value of String: "+s); //normal concat
            Console.WriteLine($"Value of String: {s}"); //interpolation

            //Dynamic Data Type
            //var and dynamic
            var v = 25; //compiler will decide the data type at compile time
            Console.WriteLine($"datatype of var decided at runtime : {v}");

            dynamic dy = 20.32; //data type will be decided at runtime
            Console.WriteLine($"datatype of dynamic decided at runtime : {dy}");
            dy = "Changed to String"; //reassigned to string
            Console.WriteLine($"datatype changed to String at runtime : {dy}");


            /* Console Output:
             Executing from OwnProgram class
             20.11C# Selenium
             Value of i: 10
             Value of i: 10
             Value of String: C# Selenium
             Value of String: C# Selenium
             datatype of var decided at runtime: 25
             datatype of dynamic decided at runtime : 20.32
             datatype changed to String at runtime : Changed to String
            */
        }

    }
}
