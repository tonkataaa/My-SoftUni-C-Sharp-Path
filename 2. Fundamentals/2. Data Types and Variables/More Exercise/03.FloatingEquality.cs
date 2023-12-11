

decimal firstNum = decimal.Parse(Console.ReadLine());
decimal secondNum = decimal.Parse(Console.ReadLine());
decimal eps = 0.000001m;

bool areEqual = (decimal)Math.Abs(firstNum - secondNum) < eps;

Console.Write(areEqual);
	

