using System;
using System.Net;

namespace _11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());

            double result;
            Console.Write(Calculate(num1, @operator, num2));
        }


        static double Calculate(double num1, string @operator, double num2)
        {
            double result = 0;
            if (@operator == "/")
            {
                result = num1 / num2;

            }
            else if (@operator == "*")
            {
                result = num1 * num2;
            }
            else if (@operator == "+")
            {
                result = num1 + num2;
            }
            else if (@operator == "-")
            {
                result = num1 - num2;
            }
            return result;
        }
    }
}
