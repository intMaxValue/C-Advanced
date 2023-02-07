int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[size[0], size[1]];

int rows = size[0];
int cols = size[1];


for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}

int maxSum = int.MinValue;

int startingRow = 0;
int startingCol = 0;

for (int row = 0; row < rows - 2; row++)
{

    for (int col = 0; col < cols - 2; col++)
    {
        int sum = matrix[row, col] + 
                  matrix[row, col + 1] + 
                  matrix[row, col + 2] + 
                  matrix[row + 1, col] +
                  matrix[row + 1, col + 1] +
                  matrix[row + 1, col + 2] +
                  matrix[row + 2, col] +
                  matrix[row + 2, col + 1] +
                  matrix[row + 2, col + 2] ;

        if (sum > maxSum)
        {
            maxSum = sum;
            startingRow = row;
            startingCol = col;
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");

Console.WriteLine($"{matrix[startingRow, startingCol]} {matrix[startingRow, startingCol + 1]} {matrix[startingRow, startingCol + 2]}");
Console.WriteLine($"{matrix[startingRow + 1, startingCol]} {matrix[startingRow + 1, startingCol + 1]} {matrix[startingRow + 1, startingCol + 2]}");
Console.WriteLine($"{matrix[startingRow + 2, startingCol]} {matrix[startingRow + 2, startingCol + 1]} {matrix[startingRow + 2, startingCol + 2]}");