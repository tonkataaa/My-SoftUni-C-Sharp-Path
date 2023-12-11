using System;

namespace _9._Spice_Must_Flow
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int startingYield = int.Parse(Console.ReadLine());

			//Solution
			int days = 0;
			long totalSpice = 0;
			while (startingYield >= 100)
			{
				totalSpice += startingYield - 26;
				startingYield -= 10;
				days++;
			}

			if (totalSpice >= 26)
			{
				totalSpice -= 26;
			}

			//Output
			Console.WriteLine(days);
			Console.WriteLine(totalSpice);

		}
	}
}
