namespace GenericCountMethodStrings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Item<string> item = new Item<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                item.Add(input);
            }

            string inputToCompare = Console.ReadLine();

            int result = item.Compare(inputToCompare);

            Console.WriteLine(result);
        }
    }
}