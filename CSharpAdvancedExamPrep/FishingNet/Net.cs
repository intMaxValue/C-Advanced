using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; private set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count { get => Fish.Count; }

        public string AddFish(Fish fish)
        {

            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fishByWeight = Fish.FirstOrDefault(f => f.Weight == weight);
            if (fishByWeight != null)
            {
                Fish.Remove(fishByWeight);
                return true;
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fishByFishType = Fish.FirstOrDefault(f => f.FishType == fishType);
            if (fishByFishType != null)
            {
                return fishByFishType;
            }
            return null;
        }

        public Fish GetBiggestFish()
        {
            Fish biggestFish = Fish.OrderByDescending(f => f.Length).First();
            return biggestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
