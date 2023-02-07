using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split(", "));

            while (queue.Any())
            {
                string cmnd = Console.ReadLine();

                if (cmnd.StartsWith("Play"))
                {
                    queue.Dequeue();
                }
                else if (cmnd.StartsWith("Add"))
                {
                    string song = cmnd.Substring(4);
                    
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (cmnd.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
