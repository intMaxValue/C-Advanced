int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n,n];

for (int row = 0;row < n; row++)
{
	int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

	for (int col = 0; col < n; col++)
	{
		matrix[row,col] = input[col];
	}
}

int sumPrimaryDiagonal = 0;

for (int row = 0;row < n; row++)
{
	sumPrimaryDiagonal += matrix[row, row];
}

Console.WriteLine(sumPrimaryDiagonal);