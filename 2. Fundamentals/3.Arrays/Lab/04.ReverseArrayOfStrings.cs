using System;

namespace _4._Reverse_Array_of_Strings
{
	internal class Program
	{
		static void Main(string[] args)
		{			
			string[] words = Console.ReadLine()
				.Split(" ");		    
			//Solution
			Array.Reverse(words);

			for (int i = 0; i < words.Length; i++)
			{
				Console.Write(words[i] + " ");
			}

		}
	}
}
