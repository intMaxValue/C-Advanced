using System;

namespace WallDestroyer
{
    internal class Program
    {
        public static int size = 0;
        public static int rowVanko = -1;
        public static int colVanko = -1;
        public static string[,] wall;
        public static int holes = 1;
        public static int rods = 0;
        public static bool isElectrocuted = false;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            wall = new string[size, size];
            CreatingWall();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (isElectrocuted)
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                    PrintMatrix(wall);
                    return;
                }

                if (input == "down")
                {
                    Move(1, 0);
                }
                else if (input == "up")
                {
                    Move(-1, 0);
                }
                else if (input == "left")
                {
                    Move(0, -1);
                }
                else if (input == "right")
                {
                    Move(0, 1);
                }
            }

            Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            wall[rowVanko, colVanko] = "V";
            PrintMatrix(wall);
        }

        private static void PrintMatrix(string[,] wall)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            int nextRow = rowVanko + row;
            int nextCol = colVanko + col;

            if (IsInbound(nextRow, nextCol) == true)
            {
                if (wall[nextRow, nextCol] == "-")
                {
                    wall[nextRow, nextCol] = "*";
                    rowVanko = nextRow;
                    colVanko = nextCol;
                    holes++;
                }
                else if (wall[nextRow, nextCol] == "R")
                {
                    rods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[nextRow, nextCol] == "*")
                {
                    rowVanko = nextRow;
                    colVanko = nextCol;
                    Console.WriteLine($"The wall is already destroyed at position [{rowVanko}, {colVanko}]!");
                }
                else if (wall[nextRow,nextCol] == "C")
                {
                    holes++;
                    isElectrocuted = true;
                    wall[nextRow, nextCol] = "E";
                }
            }
        }
        private static void CreatingWall()
        {
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {

                    wall[row, col] = input[col].ToString();

                    if (wall[row, col] == "V")
                    {
                        rowVanko = row;
                        colVanko = col;
                        wall[row, col] = "*";
                    }
                }
            }
        }
        public static bool IsInbound(int row, int col)
        {
            if (row < 0 || row >= size || col < 0 || col >= size)
            {
                return false;
            }
            return true;
        }
    }
}
