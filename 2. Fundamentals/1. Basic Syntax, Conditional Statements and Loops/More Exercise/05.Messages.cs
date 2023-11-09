using System;
using System.Collections.Generic;
using System.Security;

namespace _05._Messages
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int n = int.Parse(Console.ReadLine());

			//Solution
			string message = string.Empty;
			for (int i = 0; i < n; i++)
			{
				string currentNum = Console.ReadLine();
				int mainDigit = int.Parse(currentNum[0].ToString());
				int length = currentNum.Length;
				if (currentNum == "0")
				{
					message += " ";
					continue;
				}

				int offset = (mainDigit - 2) * 3;
				if (8 <= mainDigit && mainDigit <= 9)
				{
					offset++;
				}

				int letterIndex = (offset + length - 1) + 97;
				char letter = (char)letterIndex;
				message += letter;
			}
				//Output
				Console.WriteLine(message);
		}
	}
}


