using System;

namespace _03._Zig_Zag_Arrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int n = int.Parse(Console.ReadLine());
			string[] firstArray = new string[n];
			string[] secondArray = new string[n];

			//Solution
			bool shouldTakeFirst = true;
			for (int i = 0; i < n; i++)
			{
				string numbers = Console.ReadLine();
				string[] arrayOfNumbers = numbers
					.Split();
				
				if (shouldTakeFirst)
				{
					firstArray[i] = arrayOfNumbers[0];
					secondArray[i] = arrayOfNumbers[1];
				}
				else
				{
					firstArray[i] = arrayOfNumbers[1];
					secondArray[i] = arrayOfNumbers[0];
				}
				shouldTakeFirst= !shouldTakeFirst;
			}

			//Output
			Console.WriteLine(string.Join(" ",firstArray));
			Console.WriteLine(string.Join(" ",secondArray));
		}
	}
}
