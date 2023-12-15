using System;
using System.Linq;
using System.Xml.Schema;

namespace _02._Vowels_Count
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string word = Console.ReadLine();
			int vowels = 0;

			Console.Write(VowelsChecker(word, vowels));
		}


		static int VowelsChecker(string word, int vowels)
		{
			foreach (char vowel in word)
			{
			  if (vowel == 'a' || vowel == 'e' || vowel == 'i' || vowel == 'o' || vowel == 'u' || vowel == 'A' || vowel == 'E' || vowel == 'I' || vowel == 'O' || vowel == 'U')
				{
					vowels++;				
				}
			}
			return vowels;
		}
	}
}
