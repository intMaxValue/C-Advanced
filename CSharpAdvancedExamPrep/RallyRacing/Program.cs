using System.Runtime.ExceptionServices;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string carName = Console.ReadLine();

            string[,] track = new string[size, size];

            int carRow = 0;
            int carCol = 0;

            int totalDistance = 0;

            bool isFirstTunnel = true;
            bool isFinished = false;

            int firstTunnelRow = -1;
            int firstTunnelCol = -1;
            int secondTunnelRow = -1;
            int secondTunnelCol = -1;

            int finalRow = -1;
            int finalCol = -1;

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < size; col++)
                {
                    track[row, col] = input[col];

                    if (input[col] == "T" && isFirstTunnel)
                    {
                        firstTunnelRow = row;
                        firstTunnelCol = col;
                        isFirstTunnel = false;
                    }
                    else if (input[col] == "T" && !isFirstTunnel)
                    {
                        secondTunnelRow = row;
                        secondTunnelCol = col;
                    }
                }
            }

            string carInput = string.Empty;
            while ((carInput = Console.ReadLine().ToLower()) != "end")
            {
                if (carInput == "down")
                {
                    carRow++;
                }
                else if (carInput == "up")
                {
                    carRow--;
                }
                else if (carInput == "left")
                {
                    carCol--;
                }
                else if (carInput == "right")
                {
                    carCol++;
                }


                if (track[carRow, carCol] == ".")
                {
                    totalDistance += 10;
                }
                if (carRow == firstTunnelRow && carCol == firstTunnelCol)
                {
                    track[firstTunnelRow, firstTunnelCol] = ".";
                    carRow = secondTunnelRow;
                    carCol = secondTunnelCol;
                    track[carRow, carCol] = ".";
                    totalDistance += 30;
                }
                else if (carRow == secondTunnelRow && carCol == secondTunnelCol)
                {
                    track[secondTunnelRow, secondTunnelCol] = ".";
                    carRow = firstTunnelRow;
                    carCol = firstTunnelCol;
                    track[carRow, carCol] = ".";
                    totalDistance += 30;
                }
                if (track[carRow, carCol] == "F")
                {
                    totalDistance += 10;
                    isFinished = true;
                    Console.WriteLine($"Racing car {carName} finished the stage!");
                    break;
                }
            }

            track[carRow, carCol] = "C";

            if (isFinished == false)
            {
                Console.WriteLine($"Racing car {carName} DNF.");
            }
            Console.WriteLine($"Distance covered {totalDistance} km.");

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{track[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}