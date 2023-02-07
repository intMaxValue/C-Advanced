using System.Runtime.CompilerServices;

namespace GenericSwapMethodStrings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Item<int> items = new Item<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                items.Add(int.Parse(input));
            }

            string[] swap = Console.ReadLine().Split();

            items.Swap(int.Parse(swap[0]), int.Parse(swap[1]));

            Console.WriteLine(items.ToString());
        }
    }
}