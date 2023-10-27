using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int final = int.Parse(Console.ReadLine());


            for (int num = start; num <= final; num++)
            {
                int even = 0;
                int odd = 0;

                string currentNum = num.ToString();
                for (int j = 0; j < 6; j++)
                {




                    if (j % 2 == 0)
                    {
                        even += currentNum[j];
                    }

                    else
                    {
                        odd += currentNum[j];

                    }



                }


                if (odd == even)
                {
                    Console.Write($"{num} ");
                }



            }
        }
    }
}
