using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            float sum = 0;
            for (int i = number1; i < number2; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine(number2);
            sum += number2;

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
