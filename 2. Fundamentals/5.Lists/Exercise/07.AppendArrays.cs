using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            string input = Console.ReadLine();
            string[] arrayStrings = input
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            //Solution
            List<int> resultList = new List<int>(); // to store the result

            for (int i = arrayStrings.Length - 1; i >= 0; i--)
            {
                string[] numberStrings = arrayStrings[i]
                    .Trim()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string numberString in numberStrings)
                {
                    int number = int.Parse(numberString);
                    resultList.Add(number);
                }
            }

            //Output
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
