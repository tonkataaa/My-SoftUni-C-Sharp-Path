

using System.Data;

int line = int.Parse(Console.ReadLine());

for (int i = 0; i < line; i++)
{
	string[] numbers = Console.ReadLine()
		.Split();

	long leftNumber = long.Parse(numbers[0]);
	long rightNumber = long.Parse(numbers[1]);


	if (leftNumber > rightNumber)
	{
		Console.WriteLine(SumOfDigits(leftNumber));
	}
	else
	{
		Console.WriteLine(SumOfDigits(rightNumber));
	}
}

static int SumOfDigits (long num)
{
	int sum = 0;
	while (num != 0)
	{
		sum += (int)(num % 10);
		num /= 10;
	}

	return Math.Abs(sum);
}



