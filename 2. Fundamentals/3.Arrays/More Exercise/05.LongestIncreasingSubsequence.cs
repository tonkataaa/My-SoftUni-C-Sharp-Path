

int[] nums = Console.ReadLine().
	Split()
	.Select(int.Parse)
	.ToArray();

int[] len = new int[nums.Length];
int[] prev = new int[nums.Length];

for (int i = 0; i < nums.Length; i++)
{
	len[i] = 1;
	prev[i] = -1;

	for (int j = 0; j < i; j++)
	{
		if (nums[i] > nums[j] && len[i] < 1 + len[j])
		{
			len[i] = 1 + len[j];
			prev[i] = j;
		}
	}
}

int maxLength = len.Max();
int lastIndex = Array.IndexOf(len, maxLength);

List<int> list = new List<int>();
while (lastIndex != -1 )
{
	list.Insert(0, nums[lastIndex]);
	lastIndex = prev[lastIndex];
}

Console.WriteLine(string.Join(" ", list));
