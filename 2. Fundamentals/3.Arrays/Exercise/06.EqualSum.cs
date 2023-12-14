using System;
using System.Linq;

namespace _6._Equal_Sums
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int foundIndex = -1;

			for (int i = 0; i < array.Length; i++)
			{
				int leftSum = 0;
				int rightSum = 0;


				for (int l = 0; l < i; l++)
				{
					leftSum += array[l];
				}


				for (int r = i + 1; r < array.Length; r++)
				{
					rightSum += array[r];
				}


				if (leftSum == rightSum)
				{
					foundIndex = i;
					break;
				}
			}


			if (foundIndex != -1)
			{
				Console.WriteLine(foundIndex);
			}
			else
			{
				Console.WriteLine("no");
			}
		}
	}
}
