﻿
using System.Runtime.CompilerServices;

int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int rows = size[0];
int cols = size[1];

string snake = Console.ReadLine();
string snakeReversed = snake.Reverse().ToString();

string[,] matrix = new string[rows, cols];
int curr = 0;

for (int row = 0; row < rows; row++)
{
	if (row % 2 == 0)
	{
		for (int col = 0; col < cols; col++)
		{
			matrix[row, col] = snake[curr].ToString();
			curr++;

			if (curr == snake.Length)
			{
				curr = 0;
			}
		}
	}
	else
	{
		for (int col = cols - 1; col >= 0; col--)
		{
			
			matrix[row, col] = snake[curr].ToString();
			curr++;

            if (curr == snake.Length)
            {
                curr = 0;
            }
        }
    }
}

for (int row = 0; row < rows; row++)
{
	for (int col = 0; col < cols; col++)
	{
		Console.Write(matrix[row, col]);
	}
	Console.WriteLine();
}