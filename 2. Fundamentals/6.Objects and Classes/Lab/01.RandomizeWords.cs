using System;

namespace _01._Randomize_Words
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine()
				.Split();

			Random randomIndex = new Random();

			for (int i = 0; i < input.Length; i++)
			{
				int nextIndex = randomIndex.Next(0, input.Length);

				string currentWord = input[i];
				string nextWord = input[nextIndex];

				input[i] = nextWord;
				input[nextIndex] = currentWord;
			}

			Console.WriteLine(string.Join(Environment.NewLine, input));
		}
	}
}
