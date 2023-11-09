using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            float total = 0;
            float pricePerPerson = 0;

            if (groupType == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 8.45f;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 9.80f;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 10.46f;
                }

                total = countOfPeople * pricePerPerson;
                if (countOfPeople >= 30)
                {
                    total -= total * 0.15f;
                }
            }
            else if (groupType == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 10.90f;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 15.60f;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 16f;
                }

                if (countOfPeople >= 100)
                {
                    countOfPeople -= 10;
                }

                total = countOfPeople * pricePerPerson;               
            }
            else if (groupType == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 15f;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 20f;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 22.50f;
                }

                total = countOfPeople * pricePerPerson;

                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    total -= total * 0.05f;
                }
            }
            Console.WriteLine($"Total price: {total:f2}");
      }
    }
}
