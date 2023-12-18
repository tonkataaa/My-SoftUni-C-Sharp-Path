using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
namespace _01._Train
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<int> list = Console.ReadLine()
				  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
				  .Select(int.Parse)
				  .ToList();

			int maxCapacity = int.Parse(Console.ReadLine());

			//Solution
			string input;
			while ((input = Console.ReadLine()) != "end")
			{
				string[] commandArgs = input
					.Split(' ');

				string commandType = commandArgs[0];

				if (commandType == "Add")
				{
					int value = int.Parse(commandArgs[1]);
					list.Add(value);
					continue;
				}
				else
				{
					int passengers = int.Parse(commandArgs[0]);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i] + passengers <= maxCapacity)
						{
							list[i] += passengers;
							break;
						}
					}
				}

			}

			//Output
				Console.WriteLine(string.Join(" ", list));
		}
	}
}
