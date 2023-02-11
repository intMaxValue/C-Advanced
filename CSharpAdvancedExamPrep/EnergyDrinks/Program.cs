namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> drinks = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int totalCaffeine = 0;

            while (caffeine.Any() && drinks.Any())
            {
                int lastCaffeine = caffeine.Pop();
                int lastDrink = drinks.Dequeue();

                int milligarms = lastCaffeine * lastDrink;

                if (totalCaffeine+milligarms <= 300)
                {
                    totalCaffeine+= milligarms;
                }
                else
                {
                    drinks.Enqueue(lastDrink);
                    totalCaffeine -= 30;
                    if (totalCaffeine < 0)
                    {
                        totalCaffeine = 0;
                    }
                }
            }

            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}