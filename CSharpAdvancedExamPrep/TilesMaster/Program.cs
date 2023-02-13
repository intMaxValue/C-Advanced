using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                {"Sink", 40},
                {"Oven", 50},
                {"Countertop", 60},
                {"Wall", 70}
            };

            Dictionary<string, int> usedTiles = new Dictionary<string, int>();

            while (whiteTiles.Any() && greyTiles.Any())
            {
                int currWhite = whiteTiles.Pop();
                int currGrey = greyTiles.Dequeue();
                int sum = currWhite + currGrey;
                bool isEqual = currWhite == currGrey;

                if (isEqual)
                {
                    string place = WhereItFits(table, sum);

                    if (!usedTiles.ContainsKey(place))
                    {
                        usedTiles.Add(place, 0);
                    }
                    usedTiles[place]++;
                }
                else
                {
                    whiteTiles.Push(currWhite / 2);
                    greyTiles.Enqueue(currGrey);
                }

            }

            string whiteLeft = whiteTiles.Any() == false? "none": string.Join(", ", whiteTiles);
            string greyLeft = greyTiles.Any() == false ? "none" : string.Join(", ", greyTiles);

            Console.WriteLine($"White tiles left: {whiteLeft}");
            Console.WriteLine($"Grey tiles left: {greyLeft}");

            foreach (var item in usedTiles.Where(t=>t.Value >0).OrderByDescending(t=>t.Value).ThenBy(t=>t.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static string WhereItFits(Dictionary<string, int> table, int sum)
        {
            foreach (var item in table)
            {
                if (item.Value == sum)
                {
                    return item.Key.ToString();
                }
            }
            return "Floor";
        }
    }
}
