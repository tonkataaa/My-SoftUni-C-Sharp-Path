

int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());

CheckProductSign(num1, num2, num3);

static void CheckProductSign(int num1, int num2, int num3)
{
	int negativeCount = 0;

	if (num1 < 0)
	{
		negativeCount++;
	}

	if (num2 < 0)
	{
		negativeCount++;
	}

	if (num3 < 0)
	{
		negativeCount++;
	}

	if (negativeCount % 2 == 0)
	{
		if (num1 == 0 || num2 == 0 || num3 == 0)
		{
			Console.WriteLine("zero");
		}
		else
		{
			Console.WriteLine("positive");
		}
	}
	else
	{
		Console.WriteLine("negative");
	}
}
