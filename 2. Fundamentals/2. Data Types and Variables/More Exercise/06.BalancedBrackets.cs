

int range = int.Parse(Console.ReadLine());

int openingBracketsCount = 0;
int closingBracketsCount = 0;
for (int i = 0; i <= range; i++)
{
	string input = Console.ReadLine();
	if (input == "(")
	{
		openingBracketsCount++;
	}
	else if (input == ")")
	{
		closingBracketsCount++;
	}

	if (closingBracketsCount > openingBracketsCount)
	{
		Console.WriteLine("UNBALANCED");
		return;
	}
}

if (openingBracketsCount == closingBracketsCount)
{
	Console.Write("BALANCED");
}
else
{
	Console.Write("UNBALANCED");
}