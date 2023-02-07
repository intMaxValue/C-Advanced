using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> ints = new Queue<int>(input);

            List<int> output = new List<int>();

            while (ints.Any())
            {
                int currNum = ints.Dequeue();

                if (currNum % 2 == 0)
                {
                    output.Add(currNum);
                }
            }

            Console.WriteLine($"{string.Join(", ", output)}");
        }
    }
}
