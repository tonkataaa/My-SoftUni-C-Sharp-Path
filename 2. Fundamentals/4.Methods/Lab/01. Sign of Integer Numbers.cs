using System;

namespace _01._Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Sign(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (number == 0)
            { 
                Console.WriteLine($"The number {number} is zero.");           
            }
        }



        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Sign(number);
        }


    }
}
