using System;

namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            int lastdigit;
            for (int i = 1; i <= n; i++)
            {
                lastdigit = i;
                double sum = 0;
                while (lastdigit > 0)
                {
                    sum += (lastdigit % 10);
                    lastdigit /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

            }
        }
    }
}
