using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _02._Common_Elements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			string[] firstArray = Console.ReadLine()
				.Split()
				.ToArray();

			string[] secondArray = Console.ReadLine()
				.Split()
				.ToArray();

			//Solution + Output
			for (int i = 0; i < secondArray.Length; i++)
			{
				for (int j = 0; j < firstArray.Length; j++)
				{
					if (secondArray[i] == firstArray[j])
					{
						Console.Write(secondArray[i] + " ");			
					}
				}
			}
		}
	}
}
