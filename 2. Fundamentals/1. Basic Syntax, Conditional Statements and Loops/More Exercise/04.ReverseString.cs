using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Reverse_String
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string text = Console.ReadLine();
			
			//Solution
			char[] textArray = text.ToCharArray();
			Array.Reverse(textArray);
			string reversed = new string(textArray);


			//Output
			Console.WriteLine(reversed);
		}
	}
}