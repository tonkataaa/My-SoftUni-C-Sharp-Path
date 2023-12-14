using System;
using System.Linq;
namespace _06._Even_and_Odd_Subtraction
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
			int evenSum = 0; //to store even sum
			int oddSum = 0; //to store odd sum

			for (int i = 0; i < numbers.Length; i++)
			{
				int currentNum = numbers[i];

				if (currentNum % 2 == 0)
				{
					evenSum += currentNum;
				}					
				else /*(currentNum % 1 == 0) ==> също става*/
				{
					oddSum += currentNum;
				}
			}
			int substraction = evenSum - oddSum;
			Console.Write(substraction);

		}
	}
}
