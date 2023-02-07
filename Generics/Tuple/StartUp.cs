namespace Tuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{input1[0]} {input1[1]}";
            string address = input1[2];

            Tuple<string, string> tuple1 = new(fullName, address);

            string[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = input2[0];
            int beer = int.Parse(input2[1]);

            Tuple<string, int> tuple2 = new(name, beer);

            string[] input3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int @integer = int.Parse(input3[0]);
            double @double = double.Parse(input3[1]);

            Tuple<int, double> tuple3 = new(@integer, @double);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());


        }
    }
}