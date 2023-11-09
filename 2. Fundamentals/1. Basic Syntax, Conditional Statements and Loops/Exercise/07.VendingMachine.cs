using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace _07.VendingMachine
{ 
	class Program
    {
        static void Main(string[] args)
        {
            string putCoins = Console.ReadLine();

            decimal totalCoins = 0;
            while (putCoins != "Start")
            {
                decimal coins = decimal.Parse(putCoins);

                if (putCoins == "0.1" || putCoins == "0.2" || putCoins == "0.5" ||
                    putCoins == "1" || putCoins == "2")
                {
                    totalCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {putCoins}");
                }
                  
                putCoins = Console.ReadLine();
            }
            
            string buyProduct;
            while ((buyProduct = Console.ReadLine()) != "End")
            {
                decimal nutsPrice = 2.0m;
                decimal waterPrice = 0.7m;
                decimal crispsPrice = 1.5m;
                decimal sodaPrice = 0.8m;
                decimal cokePrice = 1.0m;

                if (buyProduct == "Nuts" && totalCoins >= nutsPrice)
                {
                    totalCoins -= nutsPrice;
                    Console.WriteLine("Purchased nuts");
                }
                else if (buyProduct == "Water" && totalCoins >= waterPrice)
                {
                    totalCoins -= waterPrice;
					Console.WriteLine("Purchased water");
				}
                else if (buyProduct == "Crisps" && totalCoins >= crispsPrice)
                {
                    totalCoins -= crispsPrice;
					Console.WriteLine("Purchased crisps");
				}
                else if (buyProduct == "Soda" && totalCoins >= sodaPrice)
                {
                    totalCoins -= sodaPrice;
					Console.WriteLine("Purchased soda");
				}
                else if (buyProduct == "Coke" && totalCoins >= cokePrice)
                {
                    totalCoins -= cokePrice;
					Console.WriteLine("Purchased coke");
				}
                else
                {
                    Console.WriteLine($"Sorry, not enough money");
                }
            }

            Console.WriteLine($"Change: {totalCoins:f2}");
		}
    }
}
