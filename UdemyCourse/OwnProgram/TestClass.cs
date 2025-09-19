using System.Dynamic;
using UdemyCourse.OwnProgram;

Console.WriteLine("Executing without main class");
Console.WriteLine("This is from Test Class");

//call from OwnClass
OwnClass OC = new OwnClass();
OC.CallInAC();