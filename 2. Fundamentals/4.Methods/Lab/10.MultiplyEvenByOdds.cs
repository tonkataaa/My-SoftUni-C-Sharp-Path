using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }


        static int GetMultipleOfEvenAndOdds(int number)
        {
            int result = GetSumOfOddDigits(number) * GetSumOfEvenDigits(number);
            return result;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evensSum = 0;
            while (number != 0)
            {
                int nextNum = number % 10;

                if (nextNum % 2 == 0)
                {
                    evensSum += nextNum;
                }
                number -= nextNum;
                number /= 10;
            }
            return evensSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddsSum = 0;
            while (number != 0)
            {
                int nextNum = number % 10;

                if (nextNum % 2 == 1)
                {
                    oddsSum += nextNum;
                }
                number -= nextNum;
                number /= 10;
            }
            return oddsSum;
        }
    }
}
