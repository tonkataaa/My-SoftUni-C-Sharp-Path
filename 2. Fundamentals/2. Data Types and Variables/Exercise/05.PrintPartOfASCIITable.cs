using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

			//Solution
            		
			for (int i = n1; n1 < n2; n1++)
            {
				char asciiChar1 = (char)n1;			
				Console.Write(asciiChar1 + " ");         
            }
            char asciiChar2 = (char)n2; 

            //Output
            Console.Write(asciiChar2);
        }
    }
}
