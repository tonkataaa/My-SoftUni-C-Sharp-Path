using System;
using System.Collections.Generic;
using System.Xml;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            List <string> strings = new List <string> ();
            int numberOfCommands = int.Parse(Console.ReadLine());
            //Solution
            for (int i = 0; i < numberOfCommands; i++) 
            { 
                string[] commandArgs = Console.ReadLine()
                    .Split (' ');

                string name = commandArgs[0];
                if (commandArgs.Length == 3 ) 
                { 
                  //is going
                    if (strings.Contains (name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }
                    strings.Add(name);
                }
                else if (commandArgs.Length == 4)
                {
                    //is not going
                    if (!strings.Contains (name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }
                    strings.Remove(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, strings));
        }
    }
}