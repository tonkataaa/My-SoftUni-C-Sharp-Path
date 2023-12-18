using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int productsBought = int.Parse(Console.ReadLine());
			List<string> products = new List<string>();

			//Solution

			//Read them from the Console
			for (int i = 0; i < productsBought; i++)
			{
				products.Add(Console.ReadLine());
			}

			//Sort them
			products.Sort();
			for (int i = 0; i < products.Count; i++)
			{
				//Output
				Console.WriteLine($"{i + 1}.{products[i]}");
			}
		}
	}
}
