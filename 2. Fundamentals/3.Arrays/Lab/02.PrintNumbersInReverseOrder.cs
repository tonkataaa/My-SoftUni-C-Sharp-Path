using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input:
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            //Read from console
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            //Solution:

            //Reverse the array
            Array.Reverse(numbers);

            //Output
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
