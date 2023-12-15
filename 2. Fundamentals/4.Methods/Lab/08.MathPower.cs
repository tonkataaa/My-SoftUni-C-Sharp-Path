using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            double result = Math.Pow(number1, number2);
            Console.WriteLine(result);
        }

        static double MathPower(double number1, double number2)
        {           
            double result = 1;           
                for (int i = 0; i < number2; i++)
                {
                    result *= number1;
                }
                      
            return result;


        }
    }
}
