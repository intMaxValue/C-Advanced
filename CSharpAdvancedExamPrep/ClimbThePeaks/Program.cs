using System.Reflection.Metadata.Ecma335;

namespace ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peaks = new Dictionary<string, int>()
            {
                {"Vihren", 80 },
                {"Kutelo", 90 },
                {"Banski Suhodol", 100 },
                {"Polezhan", 60 },
                {"Kamenitza", 70 }
            };

            int[] foodInput = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Stack<int> food = new Stack<int>(foodInput);

            int[] staminaInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> stamina = new Queue<int>(staminaInput);

            List<string> conqueredPeaks = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                int sum = 0;

                if (CheckFoodAndStaminaStatus(food, stamina))
                {
                    sum = food.Pop() + stamina.Dequeue();
                }
                else
                {
                    break;
                }

                string currentPeak = string.Empty;
                int currentPeakDifficulty = 0;

                if (peaks.Any())
                {
                    currentPeak = peaks.Keys.First().ToString();
                    currentPeakDifficulty = peaks.Values.First();
                }
                else
                {
                    break;
                }

                if (sum >= currentPeakDifficulty)
                {
                    conqueredPeaks.Add(currentPeak);
                    peaks.Remove(currentPeak);

                    if (CheckFoodAndStaminaStatus(food, stamina) && peaks.Any())
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

            }

            if (!peaks.Any())
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
                return;
            }
            else if (peaks.Any() && conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
                return;
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
        }


        private static bool CheckFoodAndStaminaStatus(Stack<int> food, Queue<int> stamina)
        {
            if (food.Any() && stamina.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}