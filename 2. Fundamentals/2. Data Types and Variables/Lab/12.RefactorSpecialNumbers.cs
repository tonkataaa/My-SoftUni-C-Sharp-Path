using System;
using System.Diagnostics.CodeAnalysis;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            //for (int i = 1; i <= n; i++)
            //{
            //    int lastDigit = i;
            //    int sum = 0;
            //    while (i > 0)
            //    {
            //        sum += lastDigit % 10;
            //        i /= 10;
            //    }
            //    Boolean isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
            //    Console.WriteLine($"{i} -> {isSpecial}");
            //    sum = 0;
            //}

            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbersCount; i++)
            {
                int numDigitsSum = SumOfDigits(i);

                bool isNumSpecial = (numDigitsSum == 5) || (numDigitsSum == 7) || (numDigitsSum == 11);
                Console.WriteLine("{0} -> {1}", i, isNumSpecial);
            }
        }

        static int SumOfDigits(int i)
        {
            int numDigitsSum = 0;
            while (i > 0)
            {
                numDigitsSum += i % 10;
                i /= 10;
            }

            return numDigitsSum;
        }
    }
}
