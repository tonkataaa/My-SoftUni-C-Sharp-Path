using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace _11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int countOfOrders = int.Parse(Console.ReadLine());

            //Soliton
            decimal orderPrice = 0;
            decimal total = 0;
            for (int i = 0; i < countOfOrders; i++)
            {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int capsulesCount = int.Parse(Console.ReadLine());

            orderPrice = days * capsulesCount * pricePerCapsule;
            total += orderPrice;
            Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
            }

            //Ouput
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
