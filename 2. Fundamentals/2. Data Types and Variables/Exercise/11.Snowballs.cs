

using System.Numerics;

int numberOfSnowballs = int.Parse(Console.ReadLine());

BigInteger snowballValue = 0;
int highestSnow = 0;
int highestTime = 0;
int highestQuality = 0;
BigInteger highestValue = 0;
for (int i = 0; i < numberOfSnowballs; i++)
{
	int snowBallSnow = int.Parse(Console.ReadLine());
	int snowballTime = int.Parse(Console.ReadLine());
	int snowballQuality = int.Parse(Console.ReadLine());

	snowballValue = BigInteger.Pow((snowBallSnow / snowballTime), snowballQuality);

	if (snowballValue > highestValue)
	{
		highestValue = snowballValue;
		highestSnow = snowBallSnow;
		highestTime = snowballTime;
		highestQuality = snowballQuality;
	}
}

Console.Write($"{highestSnow} : {highestTime} = {highestValue} ({highestQuality})");