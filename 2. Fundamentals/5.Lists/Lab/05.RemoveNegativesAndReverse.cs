using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<double> numbers = Console.ReadLine()
				.Split()
				.Select(double.Parse)
				.ToList();

			//Solution
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] < 0)
				{
					numbers.RemoveAt(i);
					i--;
				}
			}

			//Reverse the list
			numbers.Reverse();

			//Check if it's empty
			if (numbers.Count == 0)
			{
				Console.Write("empty");
			}

			//Output
			Console.Write(string.Join(' ', numbers));
		}
	}
}
