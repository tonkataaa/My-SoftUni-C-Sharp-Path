using System;
using System.Linq;

namespace _5._Top_Integers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string[] arrayOfNumbers = Console.ReadLine()
				.Split();
			int[] numbers = new int[arrayOfNumbers.Length];

			for (int i = 0; i < arrayOfNumbers.Length; i++)
			{
				numbers[i] = int.Parse(arrayOfNumbers[i]);
			}

			//Solution
			for (int i = 0; i < numbers.Length; i++)
			{
				bool isTopInteger = true;
				for (int j = 0; j < numbers.Length; j++)
				{
					if (numbers[i] <= numbers[j])
					{
						isTopInteger = false;
						break;
					}
				}
				if (isTopInteger) 
				{
					Console.Write($"{numbers[i]} ");
				}
			}
		}
	}
}
