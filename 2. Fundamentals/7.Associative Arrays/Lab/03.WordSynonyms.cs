using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int countOfWords = int.Parse(Console.ReadLine());

			//Solution
			var dictionary = new Dictionary<string, List<string>>();
			for (int i = 0; i < countOfWords; i++)
			{
				string key = Console.ReadLine();
				string value = Console.ReadLine();

				if(!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<string>());
				}
				dictionary[key].Add(value);
		    }

			//Output
			foreach (var kvp in dictionary)
			{
				Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
			}
		}
	}
}
