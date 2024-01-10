using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string[] words = Console.ReadLine()
				.ToLower()
				.Split(' ');

			//Solution
			var dictionary = new Dictionary<string, int>();

			foreach (var word in words)
			{
				if (!dictionary.ContainsKey(word))
				{
					dictionary.Add(word, 0);
				}
				dictionary[word]++;
			}

			//Output
			foreach (var kvp in dictionary)
			{
				if (kvp.Value % 2 == 1) // we can also use kvp.Value % 2 != 0
				{
					Console.Write(kvp.Key + " ");
				}
			}
		}
	}
}
