using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app1.Models;

namespace web_app1.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int id);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool Save();
        Pokemon GetPokemonTrimToUpper(string name);

    }
}