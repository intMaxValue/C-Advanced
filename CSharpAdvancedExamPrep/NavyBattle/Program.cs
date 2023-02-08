using System.Threading.Tasks.Dataflow;

namespace NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;
            string[,] field = new string[rows, cols];

            int u9Row = -1;
            int u9Col = -1;

            int minesHit = 0;
            int cruisersSank = 0;

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = line[col].ToString();

                    if (line[col].ToString() == "S")
                    {
                        u9Row = row;
                        u9Col = col;
                        field[row, col] = "-";
                    }
                }
            }

            while (true)
            {
                if (minesHit == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{u9Row}, {u9Col}]!");
                    break;
                }
                if (cruisersSank == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    break;
                }
                int lastRow = u9Row;
                int lastCol = u9Col;

                string direction = Console.ReadLine().ToLower();

                switch (direction)
                {
                    case "up":
                        u9Row--;
                        break;
                    case "down":
                        u9Row++;
                        break;
                    case "left":
                        u9Col--;
                        break;
                    case "right":
                        u9Col++;
                        break;
                }

                if (field[u9Row, u9Col] == "-")
                {
                    field[u9Row, u9Col] = "S";
                    field[lastRow, lastCol] = "-";
                }
                else if (field[u9Row, u9Col] == "*")
                {
                    minesHit++;
                    field[u9Row, u9Col] = "S";
                    field[lastRow, lastCol] = "-";
                }
                else if (field[u9Row, u9Col] == "C")
                {
                    cruisersSank++;
                    field[u9Row, u9Col] = "S";
                    field[lastRow, lastCol] = "-";
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{field[i,j]}");
                }
                Console.WriteLine();
            }
        }
    }
}