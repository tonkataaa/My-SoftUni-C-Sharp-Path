using System;

namespace Data_Types_and_Variables___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int meters = int.Parse(Console.ReadLine());

            //Solution
            decimal kilometers = Math.Round((decimal)meters / 1000, 2);

            //Output
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
