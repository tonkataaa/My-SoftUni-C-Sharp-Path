using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.Multiplication_Table2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier <= 10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {i} = {number * i}");
                }
            }
            else
            {
                multiplication = number * multiplier;
                Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
            }
            
        }
    }
}
