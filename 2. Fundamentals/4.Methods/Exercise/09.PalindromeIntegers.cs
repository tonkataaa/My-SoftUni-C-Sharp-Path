using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _9._Palindrome_Integers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input;
			while ((input = Console.ReadLine()) != "END")
			{
				char[] digits = input.ToCharArray();
				Array.Reverse(digits);

				string reversedNumber = new string(digits);

				if (reversedNumber == input) 
				{
					Console.WriteLine("true");
				}
				else
				{
					Console.WriteLine("false");
				}
			}
		}	
	}
}
