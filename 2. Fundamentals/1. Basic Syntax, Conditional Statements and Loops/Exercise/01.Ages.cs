using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            switch (age)
            {

                case 1:
                    if (age >= 0 && age <= 2)
                    Console.WriteLine("baby");
                    break;
                case 2:
                    if (age >= 3 && age <= 13)
                        Console.WriteLine("child");
                    break;
                case 3:
                    if (age >= 14 && age <= 19)
                        Console.WriteLine("teenager");
                    break;
                case 4:
                    if (age >= 20 && age <= 65)
                        Console.WriteLine("adult");
                    break;
                case 5:
                    if (age >= 66)
                        Console.WriteLine("elder");
                    break;
            }
               
        }
    }
}
