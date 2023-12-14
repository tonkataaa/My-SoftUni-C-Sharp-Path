using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _01._Train
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int numberOfWagons = int.Parse(Console.ReadLine());
			int[] peopleInEachWagon = new int [numberOfWagons];

			int currentPeopleInWagon = 0;
			int totalPeople = 0;

			//Solution
			for (int i = 0; i < peopleInEachWagon.Length; i++)
			{
				peopleInEachWagon[i] = int.Parse(Console.ReadLine());
				currentPeopleInWagon = peopleInEachWagon[i];
				totalPeople += currentPeopleInWagon;
			}

			//Output				
			Console.WriteLine(string.Join (" ", peopleInEachWagon));
		    Console.WriteLine(totalPeople);
		}
	}
}
