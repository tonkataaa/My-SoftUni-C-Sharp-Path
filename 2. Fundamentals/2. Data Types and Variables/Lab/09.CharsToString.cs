using System;

namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());


            //Output
            Console.WriteLine((string)$"{firstChar}{secondChar}{thirdChar}");
        }
    }
}
