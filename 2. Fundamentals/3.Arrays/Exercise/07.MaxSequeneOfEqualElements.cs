using System;

namespace _7._Max_Sequence_of_Equal_Elements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string[] symbols = Console.ReadLine()
				.Split();

			//Solution
			int bestCount = 0;
			string bestSymbolCount = String.Empty;

			for (int i = 0; i < symbols.Length; i++)
			{
				int count = 0;
				for (int j = 0; j < symbols.Length; j++)
				{
					if (symbols[i] == symbols[j])
					{
						count++;
						if (bestCount < count)
						{
							bestCount = count;
							bestSymbolCount = symbols[i];
						}
					}
					else
					{
						break;
					}
				}
			}

			for (int i = 0; i < bestCount; i++)
			{
				Console.Write(bestSymbolCount + " ");
			}
		}
	}
}
