using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> stack = new Stack<string>(input.Reverse());

            int sum = 0;

            while (stack.Any())
            {
                
                string curr = stack.Pop();
                

                if (curr == "+")
                {
                    sum += int.Parse(stack.Pop());
                }
                else if (curr == "-")
                {
                    sum -= int.Parse(stack.Pop());
                }
                else
                {
                    sum += int.Parse(curr);
                }
            }

            Console.WriteLine(sum);
        }
    }
}
