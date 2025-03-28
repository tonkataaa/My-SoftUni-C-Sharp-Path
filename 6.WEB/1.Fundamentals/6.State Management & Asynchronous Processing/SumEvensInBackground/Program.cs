
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

string command;
while ((command = Console.ReadLine()) != "show")
{
	var result = SumInBackgroundThread();
	Console.WriteLine(result);
}




static long SumInBackgroundThread()
{
	return Task.Run(() =>
	{
		long sum = 0;
		for (int i = 1; i < 10000; i++)
		{
			if (i % 2 == 0)
			{
				sum += i;
			}
		}
		return sum;
	}).GetAwaiter().GetResult(); 
}