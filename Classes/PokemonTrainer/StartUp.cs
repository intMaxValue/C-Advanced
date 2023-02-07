namespace PokemonTrainer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = trainers.SingleOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new(trainerName, new List<Pokemon>());
                    trainers.Add(trainer);
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                }
            }

            string tournamentInput = string.Empty;
            while ((tournamentInput = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.ElementCheck(tournamentInput);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

            

    }
}