using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BakeryShop;

namespace BakeryShop
{
    internal class Program
    {
        static Queue<double> water;
        static Stack<double> flour;
        static Dictionary<string, double> items = new Dictionary<string, double>()
            {
                { "Croissant", 50 },
                { "Muffin", 40 },
                { "Baguette", 30 },
                { "Bagel", 20 }
            };
        static void Main(string[] args)
        {
            water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, int> finishedItems = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();

                double waterPercentage = (currWater * 100) / (currWater + currFlour);

                string matchingItem = CheckForItem(waterPercentage);

                if (matchingItem != null)
                {
                    if (!finishedItems.ContainsKey(matchingItem))
                    {
                        finishedItems.Add(matchingItem, 0);
                    }
                    finishedItems[matchingItem]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double diff = currFlour - currWater;
                    if (!finishedItems.ContainsKey("Croissant"))
                    {
                        finishedItems.Add("Croissant", 0);
                    }
                    finishedItems["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(diff);
                }

            }

            foreach (var item in finishedItems.OrderByDescending(i => i.Value).ThenBy(i=>i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            string waterLeft = !water.Any() ? "none" : string.Join(", ", water);
            string flourLeft = !flour.Any() ? "none" : string.Join(", ", flour);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }

        private static string CheckForItem(double waterPercentage)
        {
            var item = items.FirstOrDefault(i => i.Value == waterPercentage);
            if (item.Key != null)
            {
                return item.Key;
            }
            return null;
        }
    }
}
