using System;
using System.Linq;
namespace _08._Condense_Array_to_Number
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
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				for (int j = 0; j < numbers.Length - 1; j++)
				{
					 numbers[j] += numbers[j + 1];
				}
			}

			//Output
			Console.Write(numbers[0]);
		}
	}
}
