using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<int> integers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			//Solution
			bool isChecked = false;
			string input = Console.ReadLine();
			while (input != "end")
			{
				string[] parameters = input. // ==> to recive the commands
					Split();
				string command = parameters[0]; // the command

				if (command == "Add")
				{
					isChecked = true;
					int value = int.Parse(parameters[1]);
					integers.Add(value);
				}
				else if (command == "Remove")
				{
					isChecked = true;
					int value = int.Parse(parameters[1]);
					integers.Remove(value);
				}
				else if (command == "RemoveAt")
				{
					isChecked = true;
					int value = int.Parse(parameters[1]);
					integers.RemoveAt(value);
				}
				else if (command == "Insert")
				{
					isChecked = true;
					int value = int.Parse(parameters[1]);
					int index = int.Parse(parameters[2]);
					integers.Insert(index, value);
				}
				else if (command == "Contains")
				{					
					int value = int.Parse(parameters[1]);
					if (integers.Contains(value))
					{
						Console.WriteLine("Yes");
					}
					else
					{
						Console.WriteLine("No such number");
					}
				}
				else if (command == "PrintEven")
				{
					Console.WriteLine(string.Join(' ', integers.Where(x => x % 2 == 0)));
				}
				else if (command == "PrintOdd") 
				{
					Console.WriteLine(string.Join(' ', integers.Where(x => x % 2 != 0)));
				}
				else if (command == "GetSum") 
				{					
					Console.WriteLine(integers.Sum());
				}
				else if (command == "Filter") 
				{
					string condition = parameters[1];
					int valuie = int.Parse(parameters[2]);

					if (condition == "<")
					{
						Console.WriteLine(string.Join(' ', integers.Where(x => x < valuie)));
					}
					else if (condition == ">")
					{
						Console.WriteLine(string.Join(' ', integers.Where(x => x > valuie)));
					}
					else if (condition == ">=")
					{
						Console.WriteLine(string.Join(' ', integers.Where(x => x >= valuie)));
					}
					else if (condition == "<=")
					{
						Console.WriteLine(string.Join(' ', integers.Where(x => x <= valuie)));
					}
				}
				input = Console.ReadLine();
			}

			//Output
			if (isChecked)
			{
			Console.WriteLine(string.Join(' ', integers));
			}
		}
	}
}
