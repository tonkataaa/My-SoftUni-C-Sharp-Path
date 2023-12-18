using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _4._List_Operations
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
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input
                    .Split(" ");
                string commandType = commandArgs[0];

                if (commandType == "Add")
                {
                    int value = int.Parse(commandArgs[1]);
                    ints.Add(value);
                }
                else if (commandType == "Insert")
                {
                    int value = int.Parse(commandArgs[1]);
                    int index = int.Parse(commandArgs[2]);   
                    
                    if (index < 0 || index >= ints.Count) //Check if the idex is out of the bounds
                    {
                        Console.WriteLine("Invalid index");
                        continue; //restart the loop
                    }
                    ints.Insert(index, value);
                }
                else if (commandType == "Remove")
                {
                    int value = int.Parse(commandArgs[1]);
                    if (value < 0 || value >= ints.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    ints.RemoveAt(value);
                }
                else if (commandType == "Shift")
                {
                    string direction = commandArgs[1];
                    int count = int.Parse(commandArgs[2]);

                    if (direction == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstNumber = ints[0]; // get the first number
                            ints.RemoveAt(0); // remove from the first position
                            ints.Add(firstNumber); // add new number
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastNumber = ints[ints.Count - 1]; // get the last number
                            ints.RemoveAt(ints.Count - 1); // remove it
                            ints.Insert(0, lastNumber); // insert at the new position
                        }
                    }
                }               
            }

            //Output
            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
