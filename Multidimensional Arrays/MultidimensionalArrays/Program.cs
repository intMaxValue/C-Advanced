int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = rowsAndCols[0];
int cols = rowsAndCols[1];

int[,] matrix = new int[rows, cols];

int sum = 0;

for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

	for (int col = 0; col < cols; col++)
	{
		matrix[row,col] = input[col];
		sum += matrix[row, col];
	}

}

Console.WriteLine(rows);
Console.WriteLine(cols);
Console.WriteLine(sum);