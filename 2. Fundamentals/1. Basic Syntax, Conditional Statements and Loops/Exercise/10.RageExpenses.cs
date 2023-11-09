using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double trashedHeadset = 0;
            double trashedMouse = 0;
            double trashedKeyboard = 0;
            double trashedDisplay = 0;

            double expenses = 0;
            //Solution
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }

                if (i % 3 == 0)
                {
                    trashedMouse++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyboard++;
                    if (trashedKeyboard % 2 == 0)
                    {
                        trashedDisplay++;
                    }
                }
            }
            expenses = (trashedDisplay * displayPrice) + (trashedHeadset *headsetPrice ) +(trashedKeyboard * keyboardPrice) + (trashedMouse * mousePrice);



            //Output
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
