using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackSmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                { "Gladius", 70 },
                { "Shamshir", 80 },
                { "Katana", 90 },
                { "Sabre", 110 },
                { "Broadsword", 150 },
            };

            SortedDictionary<string, int> forgedSwords = new SortedDictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();
                int sum = currCarbon+ currSteel;

                string itemToForge = CheckTable(sum, table);

                if (itemToForge != null)
                {
                    AddToForgedSwords(itemToForge, forgedSwords);
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);
                }
            }

            if (forgedSwords.Any())
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            string steelLeft = !steel.Any() ? "none" : string.Join(", ", steel);
            string carbonLeft = !carbon.Any() ? "none" : string.Join(", ", carbon);

            Console.WriteLine($"Steel left: {steelLeft}");
            Console.WriteLine($"Carbon left: {carbonLeft}");

            foreach (var sword in forgedSwords.Where(s => s.Value > 0))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }

        }

        private static void AddToForgedSwords(string itemToForge, SortedDictionary<string, int> forgedSwords)
        {
            if (!forgedSwords.ContainsKey(itemToForge))
            {
                forgedSwords.Add(itemToForge, 0);
            }
            forgedSwords[itemToForge]++;
        }

        private static string CheckTable(int sum, Dictionary<string, int> table)
        {
            foreach (var item in table)
            {
                if (item.Value == sum)
                {
                    return item.Key;
                }
            }
            return null;
        }
    }
}
