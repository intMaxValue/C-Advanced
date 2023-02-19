using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace onemore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                { "Patch", 30 },
                { "Bandage", 40 },
                { "MedKit", 100 },
            };

            SortedDictionary<string, int> createdItems = new SortedDictionary<string, int>();

            while (true)
            {
                int currTextiles = textiles.Dequeue();
                int currMedicaments = medicaments.Pop();
                int sum = currTextiles + currMedicaments;

                var item = table.FirstOrDefault(i => i.Value == sum);
                if (item.Key != null)
                {
                    if (!createdItems.ContainsKey(item.Key))
                    {
                        createdItems.Add(item.Key, 0);
                    }
                    createdItems[item.Key]++;
                }
                else if (sum > 100)
                {
                    if (!createdItems.ContainsKey("MedKit"))
                    {
                        createdItems.Add("MedKit", 0);
                    }
                    createdItems["MedKit"]++;

                    medicaments.Push(medicaments.Pop() + (sum - 100));
                }
                else
                {
                    medicaments.Push(currMedicaments + 10);
                }

                if (!textiles.Any() || !medicaments.Any())
                {
                    break;
                }
            }

            if (!textiles.Any() && !medicaments.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!medicaments.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }

            if (createdItems.Any())
            {
                foreach (var item in createdItems.OrderByDescending(i => i.Value))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }

        }


    }
}
