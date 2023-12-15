using System;

namespace _9._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
		{
			string type = Console.ReadLine();

			IntCompare(type);
			CharCompare(type);
			StringCompare(type);
		}

		private static void StringCompare(string type)
		{
			if (type == "string")
			{
				string string1 = Console.ReadLine();
				string string2 = Console.ReadLine();

				int result = string.Compare(string1, string2);
				if (result < 0)
				{
					Console.Write(string2);
				}
				else if (result > 0)
				{
					Console.Write(string1);
				}
			}
		}

		private static void CharCompare(string type)
		{
			if (type == "char")
			{
				char char1 = char.Parse(Console.ReadLine());
				char char2 = char.Parse(Console.ReadLine());

				if (char1 > char2)
				{
					Console.Write(char1);
				}
				else if (char2 > char1)
				{
					Console.Write(char2);
				}
			}
		}

		private static void IntCompare(string type)
		{
			if (type == "int")
			{
				int number1 = int.Parse(Console.ReadLine());
				int number2 = int.Parse(Console.ReadLine());

				if (number1 > number2)
				{
					Console.Write(number1);
				}
				else if (number1 < number2)
				{
					Console.Write(number2);
				}
			}
		}
	}
}
