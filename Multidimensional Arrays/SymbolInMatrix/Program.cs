int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n, n];

for (int row = 0; row < matrix.GetLength(0); row++)
{
	string input = Console.ReadLine();
	char[] chars = new char[input.Length];

	for (int i = 0; i < input.Length; i++)
	{
		chars[i] = input[i];
	}

	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = input[col];
	}
}

char toFind = char.Parse(Console.ReadLine());
bool isFound = false;

for (int i = 0; i < matrix.GetLength(0); i++)
{

	for (int j = 0; j < matrix.GetLength(1); j++)
	{
		if (matrix[i,j] == toFind)
		{
			Console.WriteLine($"({i}, {j})");
			isFound = true;
			return;
		}
	}
}

if (!isFound)
{
	Console.WriteLine($"{toFind} does not occur in the matrix");
}

