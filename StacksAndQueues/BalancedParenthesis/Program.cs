using System;
using System.Linq;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string left = input.Substring(0, input.Length / 2);
            string right = input.Substring(input.Length / 2, input.Length / 2);

            if (left == right.Reverse().ToString())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
