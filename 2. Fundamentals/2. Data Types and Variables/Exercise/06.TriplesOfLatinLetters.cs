using System;

namespace _06._Triples_of_Latin_Letters
{
	internal class Program
	{
		static void Main(string[] args)
		{
			////Input			
			int n = int.Parse(Console.ReadLine());

			//Solution
			for (char i = 'a'; i < 'a' + n; i++)
			{
				for (char j = 'a'; j < 'a' + n; j++)
				{
					for (char l = 'a'; l < 'a' + n; l++)
					{
						Console.WriteLine($"{i}{j}{l}");
					}
				}
			}
		}
	}
}