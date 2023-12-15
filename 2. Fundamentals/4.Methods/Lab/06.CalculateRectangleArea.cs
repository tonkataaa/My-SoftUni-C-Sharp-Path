using System;

namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());           
            Console.WriteLine(Area(x, y));
        }


        static int Area(int x, int y)
        {
            return x * y;
        }
    }
}
