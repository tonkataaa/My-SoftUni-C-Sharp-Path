using System;

namespace _04._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int century = int.Parse(Console.ReadLine());

            //Solution
            int years = century * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
			//Output
			Console.WriteLine($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes ");
        }
    }
}
