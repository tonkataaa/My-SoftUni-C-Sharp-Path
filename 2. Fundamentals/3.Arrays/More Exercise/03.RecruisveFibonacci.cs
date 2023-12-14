

int length = int.Parse(Console.ReadLine());

int[] fibonaci = new int[length];

fibonaci[0] = 1;
if (length > 1)
{
	fibonaci[1] = 1;
}

for (int i = 1; i < fibonaci.Length - 1; i++)
{
	fibonaci[i + 1] = fibonaci[i] + fibonaci[i - 1];
}
Console.WriteLine(fibonaci[length - 1]);