// this is a singlr file to show how to compile and run a C# program without a project file, 
// and to show how to pass argments to
using System;

namespace fundamentals
{
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // print argments
            Console.WriteLine("Arguments:");
            foreach (var arg in args)            {
                Console.WriteLine(arg);
            }
        }
    }
}