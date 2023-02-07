using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int currOrder = orders.Peek();

                if (foodQuantity >= currOrder)
                {
                    orders.Dequeue();
                    foodQuantity -= currOrder;
                }
                else
                {
                    break;
                }

                if (!orders.Any())
                {
                    Console.WriteLine("Orders complete");
                    return;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
