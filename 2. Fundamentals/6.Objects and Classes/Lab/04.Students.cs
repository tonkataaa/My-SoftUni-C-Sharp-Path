using System;
using System.Collections.Generic;

namespace _04._Students
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			List<Student> students = new List<Student>();

			//Solution
			string input = Console.ReadLine();
			while (input != "end")
			{
				string[] commandArgs = input
					.Split(' ');

				string firstName = commandArgs[0];
				string lastName = commandArgs[1];
				string age = commandArgs[2];
				string homeTown = commandArgs[3];

				Student studentsInfo = new Student (firstName, lastName, age, homeTown);

				students.Add(studentsInfo);
				input = Console.ReadLine();
			}

			string town = Console.ReadLine();

			for (int i = 0; i < students.Count; i++)
			{
				Student currentStudent = students[i];

				if (town == currentStudent.HomeTown)
				{
					Console.WriteLine($"{currentStudent.FirstName} {currentStudent.LastName} is {currentStudent.Age} years old.");
				}
			}
		}
	}

	internal class Student
	{
		public Student(string firstName, string lastName, string age, string homeTown)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			HomeTown = homeTown;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Age { get; set; }

		public string HomeTown { get; set; }
	}
}