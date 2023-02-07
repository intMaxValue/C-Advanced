int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = rowsAndCols[0];
int cols = rowsAndCols[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}

for (int col = 0; col < cols; col++)
{
    int sum = 0;

    for (int row = 0; row < rows; row++)
    {
        sum += matrix[row, col];
    }
    Console.WriteLine(sum);
}