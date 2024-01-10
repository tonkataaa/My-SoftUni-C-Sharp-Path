//Input
string[] words = Console.ReadLine()
	.Split(' ')
	.Where(x => x.Length % 2 == 0) //Solution
	.ToArray();

//Output
foreach (var word in words)
{
	Console.WriteLine(word);
}