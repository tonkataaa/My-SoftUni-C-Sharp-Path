using System;

namespace _07._Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string delimiter = Console.ReadLine();

            
            //Output
            Console.Write($"{name1}{delimiter}{name2}");
        }
    }
}
