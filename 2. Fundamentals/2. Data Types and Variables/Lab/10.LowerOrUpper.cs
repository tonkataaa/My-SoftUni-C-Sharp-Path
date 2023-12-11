using System;

namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            char letter = char.Parse(Console.ReadLine());

            //Solution
            if (letter >= 'A' && letter <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
