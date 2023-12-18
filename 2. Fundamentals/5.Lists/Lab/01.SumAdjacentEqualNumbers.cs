using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<double> list = Console.ReadLine()
				.Split()
				.Select(double.Parse)
				.ToList();

			//Solution
			for (int i = 0; i < list.Count - 1; i++)
			{
				if (list[i] == list[i + 1]) // i + 1 ==> next element
				{
					list[i] += list[i + 1];
					list.RemoveAt(i + 1);
					i = -1; // to repeat the for loop
				}
			}

			//Output
			Console.Write(string.Join(' ', list));

		}
	}
}
