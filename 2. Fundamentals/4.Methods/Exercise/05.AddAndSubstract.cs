using System;
using System.Runtime.Serialization;

namespace _5._Add_and_Subtract
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			int number3 = int.Parse(Console.ReadLine());

			//Output
			Substraction(number1, number2, number3);
		}


		//Solution
		static int Substraction (int number1, int number2, int number3  )
		{
		  int sum = number1 + number2;
		  int substraction = sum - number3;
		  Console.Write(substraction);
		  return substraction;
		}	
	}
}
