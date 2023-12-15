using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            if (product == "coffee")
            {
                CoffeePrice(quantity);
                Console.WriteLine($"{quantity:f2}");
            }
            else if (product == "water")
            {
                WaterPrice(quantity);
                Console.WriteLine($"{quantity:f2}");
            }
            else if (product == "coke")
            {
                CokePrice(quantity);
                Console.WriteLine($"{quantity:f2}");
            }
            else if (product == "snacks")
            { 
                SnacksPrice(quantity);
                Console.WriteLine($"{quantity:f2}");
            }
        }


        static double CoffeePrice (double quantity) 
        { 
            double coffee = 1.50;            
            return coffee * quantity;
        }
        static float WaterPrice(int quantity)
        {
            float water = 1.00f;
            return water * quantity;           
        }
        static float CokePrice(float quantity)
        {
            float coke = 1.40f;
            return coke * quantity;           
        }
        static double SnacksPrice(double quantity) 
        {
            double snacks = 2.00f;
            return snacks * quantity;
            
        }
  
    }
}
