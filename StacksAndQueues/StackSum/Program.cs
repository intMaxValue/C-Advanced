using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(ints);

            string input;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmnd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmnd[0] == "add")
                {
                    stack.Push(int.Parse(cmnd[1]));
                    stack.Push(int.Parse(cmnd[2]));

                }
                else if (cmnd[0] == "remove")
                {
                    int count = int.Parse(cmnd[1]);

                    if (count <= stack.Count)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }

                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
