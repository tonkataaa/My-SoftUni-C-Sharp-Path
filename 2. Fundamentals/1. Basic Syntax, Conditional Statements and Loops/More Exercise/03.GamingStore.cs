using System;

namespace _03._Gaming_Store
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			decimal balance = decimal.Parse(Console.ReadLine());

			//Solution
			string input;
			decimal totalSpent = 0;
			decimal price = 0;
			while ((input = Console.ReadLine()) != "Game Time")
			{
				if (input != "OutFall 4" && input != "CS: OG" && input != "Zplinter Zell" && input != "Honored 2" && input != "RoverWatch" && input != "RoverWatch Origins Edition")
				{
					Console.WriteLine("Not Found");
					continue;
				}
			
				if (input == "OutFall 4")
				{
					price = 39.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

				if (input == "CS: OG")
				{
					price = 15.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

				if (input == "Zplinter Zell")
				{
					price = 19.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

				if (input == "Honored 2")
				{
					price = 59.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

				if (input == "RoverWatch")
				{
					price = 29.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

				if (input == "RoverWatch Origins Edition")
				{
					price = 39.99m;
					if (balance < price)
					{
						Console.WriteLine("Too Expensive");
						continue;
					}
					balance -= price;
					totalSpent += price;
					Console.WriteLine($"Bought {input}");
				}

			}
			if (balance <= 0)
			{
				Console.WriteLine("Out of money!");
				
			}
			else
			{
			Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:F2}");
			}
		}
	}
}

