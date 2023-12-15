using System;

namespace _8._Factorial_Division
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input 
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			decimal factorialForFirstNum = FactorialForTheFirstNumber(number1);
			decimal factorialForSecondNum = FactorialForTheSecondNumber(number2);
			FinalResult(factorialForFirstNum, factorialForSecondNum);
		}

		private static void FinalResult(decimal factorialForFirstNum, decimal factorialForSecondNum)
		{
			decimal result = factorialForFirstNum / factorialForSecondNum;
			Console.Write($"{result:f2}");
		}

		private static decimal FactorialForTheSecondNumber(int number2)
		{
			decimal factorialForSecondNum = 1;
			for (int i = 1; i <= number2; i++)
			{
				factorialForSecondNum *= i;
			}

			return factorialForSecondNum;
		}

		private static decimal FactorialForTheFirstNumber(int number1)
		{
			decimal factorialForFirstNum = 1;
			for (int i = 1; i <= number1; i++)
			{
				factorialForFirstNum *= i;
			}

			return factorialForFirstNum;
		}
	}
}
