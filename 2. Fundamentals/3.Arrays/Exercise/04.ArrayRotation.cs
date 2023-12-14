using System;
using System.Linq;

namespace _4._Array_Rotation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string[] arrayOfNumbers = Console.ReadLine()
				.Split();
			int rotations = int.Parse(Console.ReadLine());

			//Solution
			for (int i = 0; i < rotations; i++)
			{
				string firstNumber = arrayOfNumbers[0];

				for (int j = 0; j < arrayOfNumbers.Length - 1; j++)
				{
					arrayOfNumbers[j] = arrayOfNumbers[j - 1];
				}
				arrayOfNumbers[arrayOfNumbers.Length - 1] = firstNumber;
			}

			Console.WriteLine(string.Join(" ", arrayOfNumbers));
		}
	}
}
