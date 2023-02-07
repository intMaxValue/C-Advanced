using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        

        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;
            Pokemons = pokemons;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        
        public List<Pokemon> Pokemons { get; set; }

        public void ElementCheck(string element)
        {
            if (Pokemons.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemon currentPokemon = Pokemons[i];

                    currentPokemon.Health -= 10;

                    if (currentPokemon.Health <= 0)
                    {
                        Pokemons.Remove(currentPokemon);
                    }
                }
            }
        }

    }
}
