using System;

namespace _3._Characters_in_Range
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CharactersInRange();
		}

		private static void CharactersInRange()
		{
			//Input
			char firstLetter = char.Parse(Console.ReadLine());
			char secondLetter = char.Parse(Console.ReadLine());


			if (firstLetter > secondLetter)
			{
				char temp = firstLetter;
				firstLetter = secondLetter;
				secondLetter = temp;
			}

			//Output
			for (char i = (char)(firstLetter + 1); i < secondLetter; i++)
			{
				Console.Write(i + " ");

			}
		}
	}
}
