

string input;
while ((input = Console.ReadLine()) != "END")
{
	if (int.TryParse(input, out int integer))
	{
		Console.WriteLine($"{input} is integer type");
	}
	else if (float.TryParse(input, out float floating))
	{
		Console.WriteLine($"{input} is floating point type");
	}
	else if (char.TryParse(input, out char character))
	{
		Console.WriteLine($"{input} is character type");
	}
	else if (bool.TryParse(input, out bool booling))
	{
		Console.WriteLine($"{input} is boolean type");
	}
	else
	{
		Console.WriteLine($"{input} is string type");
	}
}