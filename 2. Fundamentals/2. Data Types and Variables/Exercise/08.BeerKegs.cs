using System;

namespace _08._Beer_Kegs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int n = int.Parse(Console.ReadLine());

			//Solution
			decimal volume = 0;
			string biggest = String.Empty;
			decimal highestVolume = 0;
			for (int i = 0; i < n; i++)
			{
				string model = Console.ReadLine();
				float radius = float.Parse(Console.ReadLine());
				int height = int.Parse(Console.ReadLine());

				volume = (decimal)(Math.PI * radius * radius * height);				
				if (volume > highestVolume)
				{
					highestVolume = volume;
					biggest = model;
				}
			}

			Console.WriteLine(biggest);
		}
	}
}
