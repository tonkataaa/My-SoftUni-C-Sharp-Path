using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _03._Merging_Lists
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<int> firstList = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> secondList = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			//Solution
			List<int> mergedList = new List<int>();
			int min = Math.Min(firstList.Count, secondList.Count);
			for (int i = 0; i < min; i++)
			{
				mergedList.Add(firstList[i]);
				mergedList.Add(secondList[i]);
			}

			//Add the remaining elements from List
			if (firstList.Count > secondList.Count)
			{
				mergedList.AddRange(firstList.Skip(secondList.Count));
			}
			else if (secondList.Count > firstList.Count)
			{
				mergedList.AddRange(secondList.Skip(firstList.Count));
			}

			//Output
			Console.Write(string.Join(' ', mergedList));
		}
	}
}
