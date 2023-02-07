using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int pushCount = int.Parse(input[0]);
            int popCount = int.Parse(input[1]);
            int findElement = int.Parse(input[2]);

            Stack<int> stack = new Stack<int>(5);
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < pushCount; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();

                }
                else
                {
                    Console.WriteLine("0");
                    break;
                }
            }

            if (stack.Contains(findElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Any())
                {

                    Console.WriteLine($"{stack.Min()}");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
