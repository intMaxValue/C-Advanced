using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int enqueueCount = input[0];
            int dequeueCount = input[1];
            int findElement = input[2];

            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < enqueueCount; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine("0");
                }
            }

            if (queue.Any())
            {
                if (queue.Contains(findElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{queue.Min()}");
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
