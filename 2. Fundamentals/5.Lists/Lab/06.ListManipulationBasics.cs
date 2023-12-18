using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
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
			string input = Console.ReadLine();
			while(input != "end") 
			{
				string[] parameters = input. // ==> to recive the commands
					Split();
				string command = parameters[0]; // the command

				if (command == "Add")
				{
					int value = int.Parse(parameters[1]);
					integers.Add(value);
				}
				else if (command == "Remove")
				{
					int value = int.Parse(parameters[1]);
					integers.Remove(value);
				}
				else if (command == "RemoveAt")
				{
					int value = int.Parse(parameters[1]);
					integers.RemoveAt(value);
				}
				else if (command == "Insert")
				{
					int value = int.Parse(parameters[1]);
					int index = int.Parse(parameters[2]);
					integers.Insert(index,value);
				}
				input = Console.ReadLine();
			}

			//Output
			Console.Write(string.Join(' ', integers));
		}
	}
}
