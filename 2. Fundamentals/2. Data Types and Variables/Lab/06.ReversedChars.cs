using System;

namespace _06._Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            char letterA = char.Parse(Console.ReadLine());
            char letterB = char.Parse(Console.ReadLine());
            char letterC = char.Parse(Console.ReadLine());

            //Solution/Output
            Console.WriteLine($"{letterC} {letterB} {letterA}");
        }
    }
}
