

int x1 = int.Parse(Console.ReadLine());
int y1 = int.Parse(Console.ReadLine());
int x2 = int.Parse(Console.ReadLine());
int y2 = int.Parse(Console.ReadLine());

if (CalculateDistance(x1, y1) <= CalculateDistance(x2, y2))
{
	PrintClosestToCenter(x1, y1);
}
else
{
	PrintClosestToCenter(x2, y2);
}

static void PrintClosestToCenter(int x, int y)
{
	Console.Write($"({x}, {y})");
}

static double CalculateDistance (int x , int y)
{
	return Math.Sqrt(x * x + y * y);
}