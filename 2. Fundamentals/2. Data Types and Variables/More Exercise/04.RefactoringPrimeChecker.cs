

int range = int.Parse(Console.ReadLine());
for (int i = 2; i <= range; i++)
{
	bool isPrime = true;
	for (int j = 2; j < i; j++)
	{
		if (i % j == 0)
		{
			isPrime = false;
			Console.WriteLine($"{i} -> false");
			break;
		}
	}
	
	if (isPrime)
	{
		Console.WriteLine($"{i} -> true");
	}	
}