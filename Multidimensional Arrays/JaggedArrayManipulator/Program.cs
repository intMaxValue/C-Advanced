
using System.Numerics;

int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for (int row = 0; row < rows; row++)
{
    int[] colInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    jagged[row] = colInput;
}

for (int row = 0; row < rows - 1; row++)
{
    if (jagged[row].Length == jagged[row + 1].Length)
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] *= 2;
            jagged[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] /= 2;
            
        }
        for (int col = 0; col < jagged[row + 1].Length; col++)
        {
            jagged[row + 1][col] /= 2;
        }
    }
}

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] cmndArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string cmnd = cmndArgs[0];
    int row = int.Parse(cmndArgs[1]);
    int col = int.Parse(cmndArgs[2]);
    int value = int.Parse(cmndArgs[3]);

    if (cmnd == "Add")
    {
        if (isInbound(jagged, row, col))
        {
            jagged[row][col] += value;
        }
    }
    else if (cmnd== "Subtract")
    {
        if (isInbound(jagged, row, col))
        {
            jagged[row][col] -= value;
        }
    }
}
    PrintJagged(jagged);

static bool isInbound(int[][] jagged, int row, int col)
{
    bool isInbound = true;

    if (row < 0 || row >= jagged.GetLength(0) ||
                col < 0 || col >= jagged[row].Length)
    {
        isInbound = false;
    }
    return isInbound;
}

static void PrintJagged(int[][] jagged)
{
    for (int row = 0; row < jagged.GetLength(0); row++)
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            Console.Write($"{jagged[row][col]} ");
        }
        Console.WriteLine();
    }
}