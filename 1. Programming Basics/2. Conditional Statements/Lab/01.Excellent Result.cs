using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
