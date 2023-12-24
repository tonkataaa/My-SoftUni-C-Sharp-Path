using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int countOfStudents = int.Parse(Console.ReadLine());

			//Solution
			List<Students> students = new List<Students>();
			for (int i = 0; i < countOfStudents; i++)
			{
				string[] info = Console.ReadLine()
					.Split(' ');

				string firstName = info[0];
				string lastName = info[1];
				double grade = double.Parse(info[2]);

				Students studentsInfo = new Students(firstName, lastName, grade);
				students.Add(studentsInfo);
			}

			//Output
			foreach (Students student in students.OrderByDescending(x => x.Grade))
			{
				Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
			}
		}
	}

	internal class Students
	{
		public Students(string firstName, string lastName, double grade)
		{
			FirstName = firstName;
			LastName = lastName;
			Grade = grade;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public double Grade { get; set; }
	}
}