namespace GenericBoxOfInteger
{
    internal class StartUP
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(int.Parse(input));
            }

            Console.WriteLine(box.ToString());
        }
    }
}