using System;
using System.Drawing;
//Create a method for printing triangles 
namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			PrintingTriangle(n);
		}

		private static void PrintingTriangle(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= i; j++)
				{
					Console.Write(j + " ");
				}
				Console.WriteLine();
			}

			for (int i = n - 1; i >= 1; i--)
			{
				for (int j = 1; j <= i; j++)
				{
					Console.Write(j + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
