using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._English_Name_of_the_Las
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			LastDigit(number);
		}


		static int LastDigit(int number)
		{
			int lastDigit = number % (10);		
			if (lastDigit == 0) { Console.Write("zero"); }
			else if (lastDigit == 1) { Console.Write("one"); }
			else if (lastDigit == 2) { Console.Write("two"); }
			else if (lastDigit == 3) { Console.Write("three"); }
			else if (lastDigit == 4) { Console.Write("four"); }
			else if (lastDigit == 5) { Console.Write("five"); }
			else if (lastDigit == 6) { Console.Write("six"); }
			else if (lastDigit == 7) { Console.Write("seven"); }
			else if (lastDigit == 8) { Console.Write("eight"); }
			else if (lastDigit == 9) { Console.Write("nine"); }
			return lastDigit;
		}
			
	}
}
