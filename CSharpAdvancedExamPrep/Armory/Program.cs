using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Armory
{
    internal class Program
    {
        static int size;
        static string[,] matrix;
        static int swordsMoney = 0;
        static bool isOut = false;
        static int officerRow = 0;
        static int officerCol = 0;
        static int mirrorOneRow = 0;
        static int mirrorOneCol = 0;
        static int mirrorTwoRow = 0;
        static int mirrorTwoCol = 0;
        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            matrix = new string[size, size];
            GenerateMatrix();
            FindOfficerAndMirrors();


            while (true)
            {
                string input = Console.ReadLine();

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

                if (swordsMoney >= 65)
                {
                    matrix[officerRow, officerCol] = "A";
                    break;
                }
                if (isOut)
                {
                    break;
                }

            }

            if (isOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            if (swordsMoney >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {swordsMoney} gold coins.");

            PrintMatrix();
        }

        private static void Move(int row, int col)
        {
            if (IsOut(row, col))
            {
                isOut= true;
                return;
            }

            int theDigit = 0;
            bool isDigit = int.TryParse(matrix[officerRow + row, officerCol + col], out theDigit);

            if (matrix[officerRow + row, officerCol + col] == "-")
            {
                officerRow += row;
                officerCol += col;
            }
            else if (isDigit)
            {
                officerRow+= row;
                officerCol+= col;
                swordsMoney += theDigit;
                matrix[officerRow, officerCol] = "-";
            }
            else if (officerRow + row == mirrorOneRow && officerCol + col == mirrorOneCol)
            {
                matrix[officerRow + row, officerCol + col] = "-";
                officerRow = mirrorTwoRow;
                officerCol = mirrorTwoCol;
                matrix[officerRow, officerCol] = "-";
            }
            else if (officerRow + row == mirrorTwoRow && officerCol + col == mirrorTwoCol)
            {
                matrix[officerRow + row, officerCol + col] = "-";
                officerRow = mirrorOneRow;
                officerCol = mirrorOneCol;
                matrix[officerRow, officerCol] = "-";
            }

        }

        private static bool IsOut(int row, int col)
        {
            if (officerRow + row < 0 || officerCol + col < 0 ||
                officerRow + row >= size || officerCol + col >= size)
            {
                return true;
            }
            return false;
        }
        private static void FindOfficerAndMirrors()
        {
            bool isFirst = true;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "A")
                    {
                        officerCol = col;
                        officerRow = row;
                        matrix[officerRow, officerCol] = "-";
                    }
                    if (matrix[row, col] == "M" && isFirst)
                    {
                        mirrorOneRow = row;
                        mirrorOneCol = col;
                        isFirst = false;
                    }
                    if (matrix[row, col] == "M" && !isFirst)
                    {
                        mirrorTwoRow = row;
                        mirrorTwoCol = col;
                    }
                }
            }
        }

        private static void GenerateMatrix()
        {
            for (int row = 0; row < size; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInput[col].ToString();
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
