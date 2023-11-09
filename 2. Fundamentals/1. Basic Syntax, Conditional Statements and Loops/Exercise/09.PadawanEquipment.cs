using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double totalMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            //Solution
            double percent = (double)countOfStudents * 10 / 100;
            double allSabers = countOfStudents + Math.Ceiling(percent);
            double sabers = priceOfLightsaber * allSabers;

            double robes = priceOfRobe * countOfStudents;

            double beltsDiss = countOfStudents - Math.Ceiling((double)(countOfStudents / 6));
            double belts = priceOfBelt * beltsDiss;

            double total = sabers + robes + belts;

            double beltsdiss = countOfStudents - Math.Ceiling((double)(countOfStudents/ 6));

            //Output
            if (total <= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {total - totalMoney:f2}lv more.");                      
            }

        }
    }
}
