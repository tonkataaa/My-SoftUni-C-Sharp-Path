using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Gauss__Trick
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<int> list = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			//Solution
			List<int> result = new List<int>();
			for (int i = 0; i < list.Count / 2; i++)
			{
				int currentSum = list[i] + list[list.Count - 1 - i];
				result.Add(currentSum);
			}

			if (list.Count % 2 == 1) 
			{ 
			 result.Add(list[list.Count / 2 ]);
			}

			//Output
			Console.Write(string.Join(' ', result));
		}
	}
}
