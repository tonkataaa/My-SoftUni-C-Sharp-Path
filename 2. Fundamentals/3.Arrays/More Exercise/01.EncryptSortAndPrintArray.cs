



int length = int.Parse(Console.ReadLine());

string[] text = new string[length];
for (int i = 0; i < length; i++)
{
	string input = Console.ReadLine();
	text[i] = input;
}

List<int> allSums = new List<int>();
foreach (string input in text)
{
	int sum = 0;
	for (int i = 0; i < input.Length; i++)
	{
		char letter = input[i];
		if ("aeiouAEIOU".Contains(letter))
		{
			sum += letter * input.Length;
		}
		else
		{
			sum += letter / input.Length;
		}

	}
	allSums.Add(sum);
}

allSums.Sort();
foreach (var values in allSums)
{
	Console.WriteLine(values);
}