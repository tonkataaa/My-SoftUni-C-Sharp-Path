using System;
using System.Linq;
namespace _10._Top_Number
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			PrintTopNumbersUpTo(n);
		}
		private static void PrintTopNumbersUpTo(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				if (IsDigitSumDivisibleBy8(i) && HasOddDigit(i))
					Console.WriteLine(i);
			}
		}

		private static bool HasOddDigit(int n)
		{
			while (n > 0)
			{
				if ((n % 10) % 2 == 1)
					return true;
				n /= 10;
			}

			return false;
		}

		private static bool IsDigitSumDivisibleBy8(int n)
		{
			int digitSum = 0;
			while (n > 0)
			{
				digitSum += n % 10;
				n /= 10;
			}

			if (digitSum % 8 == 0)
				return true;

			return false;
		}
	}
}
