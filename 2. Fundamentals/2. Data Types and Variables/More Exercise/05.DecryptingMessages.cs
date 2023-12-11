

int key = int.Parse(Console.ReadLine());

int range = int.Parse(Console.ReadLine());

string word = String.Empty;
for (int i = 0; i < range; i++)
{
	char letter = char.Parse(Console.ReadLine());
	int decryptedChar = letter + key;

	word += (char)decryptedChar;
}

Console.Write(word);