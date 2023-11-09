using System;
using System.Collections.Generic;

namespace _01._Sort_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int[] numbers = new int[3];

			//Solution
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = int.Parse(Console.ReadLine());
			}

			Array.Sort(numbers);
			Array.Reverse(numbers);
			//Output
			for (int i = 0; i < numbers.Length; i++)
			{
				Console.WriteLine(numbers[i]);
			}

		}
	}
}
