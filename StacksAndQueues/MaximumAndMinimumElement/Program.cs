using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (query[0] == 1)
                {
                    int element = query[1];

                    stack.Push(element);
                }
                else if (query[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (query[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine($"{stack.Max()}");
                    }
                }
                else if (query[0] == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine($"{stack.Min()}");
                    }
                }
            }

            
                Console.Write(string.Join(", ", stack));
            
        }
    }
}
