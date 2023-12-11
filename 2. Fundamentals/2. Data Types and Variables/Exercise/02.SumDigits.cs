namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());

            int sum = 0;
            int currentDigit = number;
            //Solution
            while (currentDigit != 0)
            {
                int digit = currentDigit % 10;
                sum += digit;
                currentDigit /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}