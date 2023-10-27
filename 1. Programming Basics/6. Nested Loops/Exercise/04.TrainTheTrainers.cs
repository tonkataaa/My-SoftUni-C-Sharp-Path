using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();            
            int prezentionnum = 0;
            double evaluetion = 0;
            string presentationName;
            while (input != "Finish")
            {
                double prezentationEV = 0;
                presentationName = input;
                for (int i = 1; i <= n; i++)
                {
                    prezentationEV += double.Parse(Console.ReadLine());
                }
                prezentationEV = prezentationEV / n;
                evaluetion += prezentationEV;

                Console.WriteLine($"{presentationName} - {prezentationEV:F2}.");
                prezentionnum++;
                input = Console.ReadLine();

            }

            Console.WriteLine($"Student's final assessment is {evaluetion / prezentionnum:F2}.");
        }
    }
}
