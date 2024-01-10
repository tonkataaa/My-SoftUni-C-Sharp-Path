//Input
double[] numbers = Console.ReadLine()
	.Split(" ")
	.Select(double.Parse)
	.ToArray();

//Solution
var dictionary = new SortedDictionary<double, int>();
foreach (var number in numbers)
{
	if (!dictionary.ContainsKey(number))
	{
		dictionary.Add(number, 0);
	}
	dictionary[number]++;
}

//Output
foreach (var kvp in dictionary)
{
	Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
}