using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            //Solution
            int courses = (int)(Math.Ceiling((double)people / capacity));

            if (people % capacity == 2) 
            {
                
                
            }
            Console.WriteLine(courses);

        } 
    }
}
