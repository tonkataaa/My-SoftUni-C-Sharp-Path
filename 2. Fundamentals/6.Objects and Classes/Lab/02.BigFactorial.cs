using System;
using System.Numerics;

namespace _2._Big_Factorial
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int number = int.Parse(Console.ReadLine());

			//Solution
			BigInteger factorial = 1;
			for (int i = 1; i <= number; i++)
			{
				factorial *= i;
			}

			//Output
			Console.WriteLine(factorial);
		}
	}
}
