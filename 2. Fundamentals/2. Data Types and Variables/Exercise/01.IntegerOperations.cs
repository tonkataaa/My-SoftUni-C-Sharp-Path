namespace 01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int number4 = int.Parse(Console.ReadLine());

            //Solution
            int sum = number1 + number2;
            int divide = sum / number3;
            int multiply = divide * number4;

            //Output
            Console.WriteLine(multiply);
        }
    }
}