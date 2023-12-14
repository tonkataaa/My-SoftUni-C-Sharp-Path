using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int[] numbers = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.ToArray();

			//Solution
			int sum = 0; // to store the sum
			for (int i = 0; i < numbers.Length; i++)
			{
				int currentNum = numbers[i];

				if (currentNum % 2 == 0)
				{
					sum += currentNum;
				}
			}
			Console.WriteLine(sum);
		}
	}
}
