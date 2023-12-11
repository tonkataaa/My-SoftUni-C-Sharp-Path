using System;
using System.Text;

namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            int totalSum = 0;
            //Solution
            for (int i = 0; i < n; i++) 
            {
                string letters = Console.ReadLine();
                foreach (char c in letters)
                {
                    totalSum += c;
                }
            }
            //Output
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}