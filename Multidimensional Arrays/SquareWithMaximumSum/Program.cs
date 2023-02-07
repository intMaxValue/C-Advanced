int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

int[,] matrix = new int[size[0], size[1]];

int rows = size[0];
int cols = size[1];


for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}

int maxSum = int.MinValue;

int startingRow = 0;
int startingCol = 0;

for (int row = 0; row < rows - 1; row++)
{

    for (int col = 0; col < cols - 1; col++)
    {
        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

        if (sum > maxSum)
        {
            maxSum = sum;
            startingRow = row;
            startingCol = col;
        }
    }
}

Console.WriteLine($"{matrix[startingRow, startingCol]} {matrix[startingRow, startingCol + 1]}");
Console.WriteLine($"{matrix[startingRow + 1, startingCol]} {matrix[startingRow + 1, startingCol + 1]}");
Console.WriteLine(maxSum);