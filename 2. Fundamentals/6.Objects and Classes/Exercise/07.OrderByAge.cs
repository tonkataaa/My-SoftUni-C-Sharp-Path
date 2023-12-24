using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleAgeSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (string Name, int Age)> people = new Dictionary<string, (string, int)>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split(' ');
                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);

                if (!people.ContainsKey(id))
                {
                    people[id] = (name, age);
                }
                else
                {
                    people[id] = (name, age);
                }
            }

            var sortedPeople = people.Values.OrderBy(p => p.Age);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {people.FirstOrDefault(p => p.Value == person).Key} is {person.Age} years old.");
            }
        }
    }
}