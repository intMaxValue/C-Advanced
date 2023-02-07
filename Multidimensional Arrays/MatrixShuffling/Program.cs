int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = size[0];
int cols = size[1];

string[,] matrix = new string[rows,cols];

for (int row = 0; row < rows; row++)
{
    string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

	for (int col = 0; col < cols; col++)
	{
		matrix[row, col] = elements[col];
	}
}

string input = string.Empty;

while ((input = Console.ReadLine()) != "END")
{
	string[] cmnd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

	if (cmnd[0] != "swap" || cmnd.Length != 5)
	{
        Console.WriteLine("Invalid input!");
        continue;
    }
    else
	{
        int firstRow = int.Parse(cmnd[1]);
        int firstCol = int.Parse(cmnd[2]);
        int secondRow = int.Parse(cmnd[3]);
        int secondCol = int.Parse(cmnd[4]);

        if (firstRow < 0 || firstRow >= rows ||
            firstCol < 0 || firstCol >= cols ||
            secondRow < 0 || secondRow >= rows ||
            secondCol < 0 || secondCol >= cols)
        {
            Console.WriteLine("Invalid input!");
            continue;
        }
        string temp = matrix[firstRow, firstCol];
        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
        matrix[secondRow, secondCol] = temp;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }

}