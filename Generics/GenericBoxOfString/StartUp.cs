namespace GenericBoxOfString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            Console.WriteLine(box.ToString());
        }

    }
}