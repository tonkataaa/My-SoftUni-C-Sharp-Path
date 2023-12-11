using System;

namespace _07._Water_Overflow
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int n = int.Parse(Console.ReadLine());

			//Solution	
			int liters = 0;				
			for (int i = 0; i < n; i++)
			{
				int pouredLiters = int.Parse(Console.ReadLine());
				liters += pouredLiters;
				if (255 < liters)
				{
					Console.WriteLine("Insufficient capacity!");
					liters -= pouredLiters;
				}
			}

			//Output
			Console.WriteLine("{0}", liters);
		}
	}
}
