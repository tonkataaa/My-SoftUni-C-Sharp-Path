using System;
using System.Linq;
namespace _03._Rounding_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			double[] numbers = Console.ReadLine()
		     .Split(" ")
			 .Select(double.Parse)
			 .ToArray();

			//Solution + output
			for (int i = 0; i < numbers.Length; i++)
			{
				Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i])}");
			}						
		}
	}
}
