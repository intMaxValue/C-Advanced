int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for (int i = 0; i < rows; i++)
{
    int[] rowsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    
    jagged[i] = rowsInput;
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] cmnd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (cmnd.Length != 4)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }

    int row = int.Parse(cmnd[1]);
    int col = int.Parse(cmnd[2]);
    int value = int.Parse(cmnd[3]);


    if (cmnd[0] == "Add")
    {
        if (row < 0 || col < 0 || row >= rows || col >= jagged[row].Length )
        {
            Console.WriteLine("Invalid coordinates");
            continue;
        }
        else
        {
            jagged[row][col] += value;
        }
    }
    else if (cmnd[0] == "Subtract")
    {
        if (row < 0 || col < 0 || row >= rows || col >= jagged[row].Length)
        {
            Console.WriteLine("Invalid coordinates");
            continue;
        }
        else
        {
            jagged[row][col] -= value;
        }
    }
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < jagged[row].Length; col++)
    {
        Console.Write($"{jagged[row][col]} ");
    }
    Console.WriteLine();
}