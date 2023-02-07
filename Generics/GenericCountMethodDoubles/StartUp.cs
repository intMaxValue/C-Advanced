namespace GenericCountMethodDoubles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Item<double> item = new Item<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                item.Add(input);
            }

            double inputToCompare = double.Parse(Console.ReadLine());

            int result = item.Compare(inputToCompare);

            Console.WriteLine(result);
        }
    }
}