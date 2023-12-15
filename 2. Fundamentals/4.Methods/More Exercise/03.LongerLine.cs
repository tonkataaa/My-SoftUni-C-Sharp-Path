

int x1 = int.Parse(Console.ReadLine());
int y1 = int.Parse(Console.ReadLine());
int x2 = int.Parse(Console.ReadLine());
int y2 = int.Parse(Console.ReadLine());

int x3 = int.Parse(Console.ReadLine());
int y3 = int.Parse(Console.ReadLine());
int x4 = int.Parse(Console.ReadLine());
int y4 = int.Parse(Console.ReadLine());

double firstDistance = CalculateDistance(x1, y1);
double secondDistance = CalculateDistance(x1, y1);
double thirdDistance = CalculateDistance(x1, y1);
double fourthDistance = CalculateDistance(x1, y1);

if ((firstDistance <= secondDistance && firstDistance <= thirdDistance && firstDistance <= fourthDistance) 
	||
   (secondDistance <= thirdDistance && secondDistance <= fourthDistance))
{
	PrintClosestToCenter(x2, y2, x1, y1);
}
else
{
	PrintClosestToCenter(x4, y4, x3, y3);

}

static void PrintClosestToCenter(int x1, int y1, int x2, int y2)
{
	double distance1 = Math.Sqrt(x1 * x1 + y1 * y1);
	double distance2 = Math.Sqrt(x2 * x2 + y2 * y2);

	if (distance1 <= distance2)
	{
		Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
	}
	else
	{
		Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
	}
}

static double CalculateDistance(int x, int y)
{
	return Math.Sqrt(x * x + y * y);
}