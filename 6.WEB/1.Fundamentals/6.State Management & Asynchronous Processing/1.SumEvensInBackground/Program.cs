static void Main()
{
	long sum = 0;

	var task = Task.Run(() =>
	{
		for (long i = 0; i < 1000000000; i++)
		{
			if (i % 2 == 0)
			{
				sum += i;
			}
		}
	});

	while (true)
	{
		var command = Console.ReadLine();
		if (command == "exit")
		{
			return;
		}
		else if (command == "show")
		{
			Console.WriteLine(sum);
		}
	}

}