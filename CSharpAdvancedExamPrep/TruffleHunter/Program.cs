using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static int size = 0;
        static string[,] field;

        static int row = 0;
        static int col = 0;
        static string direction = string.Empty;

        static int blackTruffleCount = 0;
        static int summerTruffleCount = 0;
        static int whiteTruffleCount = 0;

        static int wbRow = 0;
        static int wbCol = 0;
        static int wildBoarTrufflesEaten = 0;

        static void Main(string[] args)
        {
            GeneratingField();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                row = int.Parse(inputArgs[1]);
                col = int.Parse(inputArgs[2]);

                if (inputArgs[0] == "Collect")
                {
                    CollectTruffle();
                }
                else if (inputArgs[0] == "Wild_Boar")
                {
                    WildBoarMove(inputArgs);
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTruffleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTrufflesEaten} truffles.");

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{field[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void WildBoarMove(string[] inputArgs)
        {
            wbRow = row;
            wbCol = col;

            direction = inputArgs[3];

            if (direction == "down")
            {
                for (int i = wbRow; i < size; i++)
                {
                    if (field[i, wbCol] != "-")
                    {
                        field[i, wbCol] = "-";
                        wildBoarTrufflesEaten++;
                        i++;
                        continue;
                    }
                    i++;
                }
            }
            else if (direction == "up")
            {
                for (int i = wbRow; i >= 0; i--)
                {
                    if (field[i, wbCol] != "-")
                    {
                        field[i, wbCol] = "-";
                        wildBoarTrufflesEaten++;
                        i--;
                        continue;
                    }
                    i--;
                }
            }
            else if (direction == "left")
            {
                for (int i = wbCol; i >= 0; i--)
                {
                    if (field[wbRow, i] != "-")
                    {
                        field[wbRow, i] = "-";
                        wildBoarTrufflesEaten++;
                        i--;
                        continue;
                    }
                    i--;
                }
            }
            else if (direction == "right")
            {
                for (int i = wbCol; i < size; i++)
                {
                    if (field[wbRow, i] != "-")
                    {
                        field[wbRow, i] = "-";
                        wildBoarTrufflesEaten++;
                        i++;
                        continue;
                    }
                    i++;
                }
            }
        }

        private static void CollectTruffle()
        {
            if (field[row, col] == "B")
            {
                field[row, col] = "-";
                blackTruffleCount++;
            }
            else if (field[row, col] == "S")
            {
                field[row, col] = "-";
                summerTruffleCount++;
            }
            else if (field[row, col] == "W")
            {
                field[row, col] = "-";
                whiteTruffleCount++;
            }
        }

        private static void GeneratingField()
        {
            size = int.Parse(Console.ReadLine());

            field = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];
                }
            }
        }
    }
}
