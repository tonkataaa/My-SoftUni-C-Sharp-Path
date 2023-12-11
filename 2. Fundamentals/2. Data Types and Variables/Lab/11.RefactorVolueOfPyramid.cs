using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            double length = double.Parse(Console.ReadLine());
            Console.Write("Length: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            height = (length * width * height) / 3;
            Console.Write($"Pyramid Volume: {height:f2}");
        }
    }
}
