using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Console.Write(Repeat(n, word));
        }


       static string Repeat(int n, string word)
        {           
            for (int i = 1; i < n; i++)
            {  
                Console.Write(word);
            }
                return word;
        }
    }
}
