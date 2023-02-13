using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                {"Cortado",50 },
                {"Espresso",75 },
                {"Capuccino",100 },
                {"Americano",150 },
                {"Latte",200 }
            };

            Dictionary<string, int> finishedDrinks = new Dictionary<string, int>();

            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            while (coffee.Any() && milk.Any())
            {
                int currCoffee = coffee.Dequeue();
                int currMilk = milk.Pop();
                int sum = currCoffee + currMilk;

                bool drinkIsMade = false;

                foreach (var item in drinks)
                {

                    if (item.Value == sum)
                    {
                        if (!finishedDrinks.ContainsKey(item.Key))
                        {
                            finishedDrinks.Add(item.Key, 0);
                        }
                        finishedDrinks[item.Key]++;
                        drinkIsMade = true;
                        break;
                    }
                }

                if (!drinkIsMade)
                {
                    milk.Push(currMilk - 5);
                }

            }

            if (!coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!coffee.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");

            }

            if (!milk.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");

            }

            foreach (var item in finishedDrinks.OrderBy(a => a.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}