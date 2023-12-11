
int pokePower = int.Parse(Console.ReadLine()); // N
int distanceBetweenPoke = int.Parse(Console.ReadLine()); // M
int exhaustionFactor = int.Parse(Console.ReadLine()); // Y

int targetsReached = 0;
decimal fiftyPercentOfNum = (decimal)pokePower * 0.5m;
while (pokePower >= distanceBetweenPoke)
{
	targetsReached++;
	pokePower -= distanceBetweenPoke;
	
	if (pokePower == fiftyPercentOfNum && exhaustionFactor != 0)
	{
		pokePower /= exhaustionFactor;
	}
}

Console.WriteLine(pokePower);
Console.WriteLine(targetsReached);

