using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int start = stack.Pop();

                    for (int j = start; j <= i ; j++)
                    {
                        Console.Write(chars[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
