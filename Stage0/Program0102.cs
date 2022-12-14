using System;

namespace Targil0
{
    partial class Program
    {   
        static void Main()
        {
            Welcome0102();
            Welcome4289();
            Console.ReadKey();
        }

        private static void Welcome0102()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine()!;
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
        static partial void Welcome4289();
    }
}



