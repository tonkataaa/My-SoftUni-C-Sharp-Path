

int numberOfRows = int.Parse(Console.ReadLine());

int[][] triangle = new int[numberOfRows][];

for (int i = 0; i < numberOfRows; i++)
{
	triangle[i] = new int[i + 1];
	triangle[i][0] = 1; // Първия елемент от реда винаги е 1


	for (int j = 1; j < i; j++)
	{
		triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
	}

	triangle[i][i] = 1; // Последния елемент от реда винаги е 1
}

foreach (var row in triangle)
{
	Console.WriteLine(string.Join(" ", row));
}