using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Exam2
{
    internal class Program
    {
        public static int rows = 0;
        public static int cols = 0;
        public static string[,] matrix;
        public static int playerRow = -1;
        public static int playerCol = -1;
        public static int moves = 0;
        public static int touchedOpponents = 0;

        static void Main(string[] args)
        {
            CreatingMatrix();
            FindPlayer();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Finish")
            {
                if (input == "up")
                {
                    if (IsInbound(-1, 0))
                    {
                        Move(-1, 0);
                    }
                }
                else if (input == "down")
                {
                    if (IsInbound(1, 0))
                    {
                        Move(1, 0);
                    }
                }
                else if (input == "left")
                {
                    if (IsInbound(0, -1))
                    {
                        Move(0, -1);
                    }
                }
                else if (input == "right")
                {
                    if (IsInbound(0, 1))
                    {
                        Move(0, 1);
                    }
                }
                if (touchedOpponents == 3)
                {
                    break;
                }
            }
            matrix[playerRow, playerCol] = "B";
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
        }

        private static void Move(int row, int col)
        {

            if (matrix[playerRow + row, playerCol + col] == "-")
            {
                matrix[playerRow, playerCol] = "-";
                playerRow += row;
                playerCol += col;
                moves++;

            }

            else if (matrix[playerRow + row, playerCol + col] == "P")
            {
                matrix[playerRow, playerCol] = "-";
                playerRow += row;
                playerCol += col;
                matrix[playerRow, playerCol] = "B";
                touchedOpponents++;
                moves++;
            }


        }

        private static void FindPlayer()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == "B")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        public static bool IsInbound(int row, int col)
        {
            if (playerRow + row < 0 || playerRow + row >= rows ||
                playerCol + col < 0 || playerCol + col >= cols)
            {
                return false;
            }
            return true;
        }

        private static void CreatingMatrix()
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            rows = size[0];
            cols = size[1];

            matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] colInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colInput[col].ToString();
                }
            }
        }
    }
}
