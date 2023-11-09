using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (0 <= age && age <= 18)
            {
                if (dayType == "Weekday")
                {
                    price = 12;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Weekend")
                {
                    price = 15;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Holiday")
                {
                    price = 5;
                    Console.WriteLine("{0}$", price);
                }
            }
            else if (18 < age && age <= 64)
            {
                if (dayType == "Weekday")
                {
                    price = 18;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Weekend")
                {
                    price = 20;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Holiday")
                {
                    price = 12;
                    Console.WriteLine("{0}$", price);
                }
            }
            else if (64 < age && age <= 122)
            {
                if (dayType == "Weekday")
                {
                    price = 12;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Weekend")
                {
                    price = 15;
                    Console.WriteLine("{0}$", price);
                }
                else if (dayType == "Holiday")
                {
                    price = 10;
                    Console.WriteLine("{0}$", price);
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }
            
        }
    }
}
