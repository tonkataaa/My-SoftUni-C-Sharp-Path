using System;
using System.Linq;

class Program
{
	static void Main()
	{
		int[] array = Console.ReadLine()
			.Split(" ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		string input;
		while ((input = Console.ReadLine()) != "end")
		{
			string[] commandArgs = input.Split();

			string command = commandArgs[0];

			if (command == "exchange")
			{
				Exchange(array, commandArgs);
			}
			else if (command == "max" || command == "min")
			{
				bool isEven = commandArgs[1] == "even";
				FindAndPrintIndex(array, command, isEven);
			}
			else if (command == "first" || command == "last")
			{
				int count = int.Parse(commandArgs[1]);
				bool isEven = commandArgs[2] == "even";
				PrintFirstOrLastElements(array, command, count, isEven);
			}
		}

		Console.WriteLine("[" + string.Join(", ", array) + "]");
	}

	static void Exchange(int[] array, string[] commandArgs)
	{
		int index = int.Parse(commandArgs[1]);
		if (index < 0 || index >= array.Length)
		{
			Console.WriteLine("Invalid index");
			return;
		}

		int[] firstSubArray = array.Take(index + 1).ToArray();
		int[] secondSubArray = array.Skip(index + 1).ToArray();

		array = secondSubArray.Concat(firstSubArray).ToArray();
	}

	static void FindAndPrintIndex(int[] array, string command, bool isEven)
	{
		int index = -1;

		for (int i = array.Length - 1; i >= 0; i--)
		{
			if ((array[i] % 2 == 0) == isEven && (index == -1 || array[i] >= array[index]))
			{
				index = i;
			}
		}

		if (index != -1)
		{
			Console.WriteLine(index);
		}
		else
		{
			Console.WriteLine("No matches");
		}
	}

	static void PrintFirstOrLastElements(int[] array, string command, int count, bool isEven)
	{
		if (count < 0 || count > array.Length)
		{
			Console.WriteLine("Invalid count");
			return;
		}

		var filteredArray = isEven ? array.Where(x => x % 2 == 0) : array.Where(x => x % 2 != 0);
		var selectedElements = command == "first" ? filteredArray.Take(count) : filteredArray.Reverse().Take(count).Reverse();

		Console.WriteLine("[" + string.Join(", ", selectedElements) + "]");
	}
}
