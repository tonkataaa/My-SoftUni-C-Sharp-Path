using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {               
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    Console.WriteLine("The number is: {0}", Math.Abs(number));
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }


        }
    }
}
