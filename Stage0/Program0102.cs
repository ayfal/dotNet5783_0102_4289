using System;

namespace Targil0
{
    partial class Program
    {   
        static void Main(string[] args)
        {
            Welcome0102();
            Wellcome4289();
            Console.ReadKey();
        }

        private static void Welcome0102()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
        static partial void Wellcome4289();
    }
}



