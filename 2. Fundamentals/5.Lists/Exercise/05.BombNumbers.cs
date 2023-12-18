using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _5._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

           List<int> specialNumAndPower = Console.ReadLine() // get the special num and power
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            //Solution
            int specialNum = specialNumAndPower[0];
            int power = specialNumAndPower[1];
            while (numbers.Contains(specialNum))
            {
                int bombIndex = numbers.IndexOf(specialNum);
                int start = bombIndex - power;
                if (start < 0)
                {
                    start = 0;
                }

                int end = bombIndex + power;
                if (end > numbers.Count)
                {
                    end = numbers.Count - 1;
                }

                numbers.RemoveRange(start, end - start + 1);

            }       
            //Output
                Console.WriteLine(string.Join(" ", numbers.Sum()));
        }
    }
}