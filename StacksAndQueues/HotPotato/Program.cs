using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            Queue<string> queue = new Queue<string>(children);

            while (queue.Count > 1)
            {
                string currentKid = queue.Dequeue();
                count++;

                if (count == n)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    count = 0;
                }
                else
                {
                    queue.Enqueue(currentKid);
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
