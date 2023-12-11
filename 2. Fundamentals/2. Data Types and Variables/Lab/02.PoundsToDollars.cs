using System;

namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            double pounds = double.Parse(Console.ReadLine());

            //Solution
            decimal dollars = (decimal)(1.31 * pounds);

            //Output
            Console.WriteLine($"{dollars:f3}");
        }
    }
}
