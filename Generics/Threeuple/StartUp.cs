namespace Threeuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{input1[0]} {input1[1]}";
            string address = input1[2];
            string town = string.Join(" ", input1[3..]);

            Threeuple<string, string, string> threeuple1 = new(fullName, address, town);

            string[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = input2[0];
            int beer = int.Parse(input2[1]);
            bool drunkOrNot = input2[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> threeuple2 = new(name, beer, drunkOrNot);

            string[] input3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name1 = input3[0];
            double accBalance = double.Parse(input3[1]);
            string bankName = input3[2];

            Threeuple<string, double, string> threeuple3 = new(name1, accBalance , bankName);

            Console.WriteLine(threeuple1.ToString());
            Console.WriteLine(threeuple2.ToString());
            Console.WriteLine(threeuple3.ToString());

        }
    }
}