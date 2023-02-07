int size = int.Parse(Console.ReadLine());

long[][] pascal = new long[size][];


for (int row = 0; row < size; row++)
{
	pascal[row] = new long[row + 1];

	for (int col = 0; col < row + 1; col++)
	{
		if (col == 0 || col == pascal[row].Length - 1)
		{
			pascal[row][col] = 1;
		}
		else
		{
			pascal[row][col] = pascal[row-1][col] + pascal[row - 1][col-1];
		}
	}
}

for (int row = 0; row < size; row++)
{
	for (int col = 0; col < pascal[row].Length; col++)
	{
		Console.Write($"{pascal[row][col]} ");
	}
	Console.WriteLine();
}