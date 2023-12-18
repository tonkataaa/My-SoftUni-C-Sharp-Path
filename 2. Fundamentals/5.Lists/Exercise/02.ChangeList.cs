using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            List<int> ints = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            //Solution
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commandArgs = input
                    .Split(" ");
                string commandType = commandArgs[0];

                if (commandType == "Delete")
                {
                    int value = int.Parse(commandArgs[1]);
                    int elementToRemove = value;
                    ints.RemoveAll(x => x == elementToRemove);                  
                }
                else if (commandType == "Insert")
                {
                    int value = int.Parse(commandArgs[1]);
                    int index = int.Parse(commandArgs[2]);
                    ints.Insert(index, value);
                }
            }

            Console.WriteLine(string.Join(" ", ints));
        }
    }
}