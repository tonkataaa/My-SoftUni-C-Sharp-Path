using System;
using System.Runtime.ConstrainedExecution;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string type = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if(type == "add")
            Calculations(number1, number2 , "add");
            if(type == "multiply")
            Calculations(number1, number2, "multiply");
            if(type == "substract")
            Calculations(number1, number2, "substract");
            if(type == "divide")
            Calculations(number1, number2, "divide");
        }


        static void Calculations (int number1, int number2, string type) 
        {
            int add = 0;
            int multiply = 0;
            int substract = 0;
            int divide = 0;

            if (type == "add")
            {
                add = number1 + number2;
                Console.WriteLine(add);
            }
            else if (type == "multiply")
            {
                multiply = number1 * number2;
                Console.WriteLine(multiply);
            }
            else if (type == "substract")
            {
                substract = number1 - number2;
                Console.WriteLine(substract);
            }
            else if (type == "divide")
            {
                divide = number1 / number2;
                Console.WriteLine(divide);
            }
        }
    }
}
