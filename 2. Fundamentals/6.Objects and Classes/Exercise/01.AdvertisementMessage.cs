using System;

namespace _01._Advertisement_Message
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int numberOfMessages = int.Parse(Console.ReadLine());

			string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.",
			"Best product of its category.", "Exceptional product.", "I can't live without this product."};

			string[] events =  {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
				 "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};

			string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

			string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

			//Solution
			Random rnd = new Random();
			for (int i = 0; i < numberOfMessages; i++)
			{
				string phrase = phrases[rnd.Next(0, phrases.Length)];
				string evenet = events[rnd.Next(0, events.Length)];
				string author = authors[rnd.Next(0, authors.Length)];
				string city = cities[rnd.Next(0, cities.Length)];

				string message = $"{phrase} {evenet} {author} - {city}.";

				//Output
				Console.WriteLine(message);
			}
		}
	}
}