using System;

namespace _08._Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            string town = Console.ReadLine();
            double population = double.Parse(Console.ReadLine());
            short area = short.Parse(Console.ReadLine());

            //Output
            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}
