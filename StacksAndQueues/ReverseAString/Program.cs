using System;
using System.Collections.Generic;

namespace ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                stack.Push(ch);
            }

            Console.WriteLine($"{string.Join("", stack)}");
        }
    }
}
