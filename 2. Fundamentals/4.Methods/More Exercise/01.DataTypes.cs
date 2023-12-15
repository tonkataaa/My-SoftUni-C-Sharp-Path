
string type = Console.ReadLine();
string value = Console.ReadLine();

DataType(type, value);


static void DataType(string type, string value)
{	
	switch (type)
	{
		case "int":
			int integer = int.Parse(value);
			integer *= 2;
			Console.WriteLine(integer);
			break;
		case "real":
			double number = double.Parse(value);
			number *= 1.5;
			Console.WriteLine($"{number:f2}");
			break;
		case "string":
			Console.WriteLine($"${value}$");
			break;
	}
}