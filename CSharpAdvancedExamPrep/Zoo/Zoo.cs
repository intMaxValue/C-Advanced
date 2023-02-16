using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; private set; }

        public string Name { get; set; }
        public int Capacity { get; set; }


        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo."; 
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimalsBySpecies = Animals.RemoveAll(a => a.Species == species);
            return removedAnimalsBySpecies;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = new List<Animal>();
            animalsByDiet = Animals.Where(a => a.Diet == diet).ToList();
            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal animalByWeight = Animals.FirstOrDefault(a => a.Weight == weight);
            return animalByWeight;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> countByLength = new List<Animal>();

            countByLength = Animals.Where(a => a.Length >= minimumLength && a.Length <= maximumLength).ToList();

            return $"There are {countByLength.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
