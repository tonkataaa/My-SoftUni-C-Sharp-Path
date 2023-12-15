using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _4._Password_Validator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string password = Console.ReadLine();
			bool isValid = true;

			isValid = PasswordLength(password, isValid);
			isValid = DoesItContainOnlyNumbersAndDigits(password, isValid);
			ContainsAtLeast2Digits(password);

			IsItValid(isValid);
		}

		private static void ContainsAtLeast2Digits(string password)
		{
			bool containsAtLeast2Digits = password.Count(char.IsDigit) >= 2;
			if (!containsAtLeast2Digits)
			{
				Console.WriteLine("Password must have at least 2 digits");
			}
		}

		private static bool DoesItContainOnlyNumbersAndDigits(string password, bool isValid)
		{
			bool containsOnlyLettersAndDigits = password.All(char.IsLetterOrDigit);
			if (!containsOnlyLettersAndDigits)
			{
				isValid = false;
				Console.WriteLine("Password must consist only of letters and digits");
			}

			return isValid;
		}

		private static bool PasswordLength(string password, bool isValid)
		{
			int passwordLength = password.Length;
			if (passwordLength < 6 || passwordLength > 10)
			{
				isValid = false;
				Console.WriteLine("Password must be between 6 and 10 characters");
			}

			return isValid;
		}

		private static void IsItValid(bool isValid)
		{
			if (isValid)
			{
				Console.WriteLine("Password is valid");
			}
		}
	}
}
