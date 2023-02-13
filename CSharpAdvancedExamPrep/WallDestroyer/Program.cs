using System;

namespace WallDestroyer
{
    internal class Program
    {
        public static int size = 0;
        public static int rowVanko = -1;
        public static int colVanko = -1;
        public static string[,] wall;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            wall = new string[size, size];
            CreatingWall();

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
                    }
                }
            }
        }
    }
}
