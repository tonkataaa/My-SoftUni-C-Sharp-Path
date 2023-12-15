using System;

namespace _6._Middle_Characters
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			MiddleCharacter(text);
		}


		private static void MiddleCharacter (string text)
		{
			
			int length = text.Length;
			if (length % 2 == 0)
			{
				Console.Write(text.Substring((text.Length / 2) - 1, 2));
			}
			else
			{
				Console.Write(text[text.Length / 2]);
			}		
		}
	}
}
