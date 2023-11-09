using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numberCopy = num;
            float factorialSum = 0;

            while (numberCopy > 0)
            {
                int digit = numberCopy % 10;
                numberCopy /= 10;

                int factorial = 1;
                for (int i = 1; i <= digit; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial; 
            }

            string isStrongNumber = factorialSum == numberCopy ? "yes" : "no";
            Console.WriteLine(isStrongNumber);
        }
    }
}
