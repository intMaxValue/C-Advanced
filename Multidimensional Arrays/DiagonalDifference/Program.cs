int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++) 
{
	string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

	for (int col = 0; col < size; col++)
	{
		matrix[row, col] = int.Parse(input[col]); 
	}
}

int primaryDiagonal = 0;
int secondaryDiagonal = 0;

for (int i = 0; i < size; i++)
{
	primaryDiagonal += matrix[i, i];
	secondaryDiagonal += matrix[i, size - i - 1];
}

Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
