using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
