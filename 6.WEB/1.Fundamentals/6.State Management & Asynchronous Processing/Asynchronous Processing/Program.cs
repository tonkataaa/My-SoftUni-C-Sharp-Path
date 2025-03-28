
int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

var evens = new Thread(() => PrintEvenNums(start, end));
evens.Start();
evens.Join();
Console.WriteLine("Thread finished working!");


static void PrintEvenNums(int start, int end)
{
	for (int i = start; i <= end; i++)
	{
		if (i % 2 == 0)
		{
			Console.WriteLine(i);
		}
	}
}