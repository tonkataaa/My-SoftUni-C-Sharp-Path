int[] input = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

int oneFourthHalf = input.Length / 4;
int[] integers = new int[4 * oneFourthHalf];
Array.Copy(input, integers, 4 * oneFourthHalf);

int[] firstRow = integers.Take(oneFourthHalf)
	.Reverse()
	.Concat(integers.Skip(3 * oneFourthHalf)
	.Take(oneFourthHalf).Reverse())
	.ToArray();

int[] secondRow = integers.Skip(oneFourthHalf)
	.Take(2 * oneFourthHalf)
	.ToArray();

int[] sumRows = firstRow.Zip(secondRow, (a, b) => a + b)
	.ToArray();

Console.WriteLine(string.Join(" ", sumRows));
