using System;

class Program
{
	static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		PrintTribonacci(num);
	}

	static void PrintTribonacci(int num)
	{
		int[] sequence = new int[num];
		sequence[0] = 1;

		if (num > 1)
			sequence[1] = 1;

		if (num > 2)
			sequence[2] = 2;

		for (int i = 3; i < num; i++)
		{
			sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
		}

		Console.WriteLine(string.Join(" ", sequence));
	}
}
