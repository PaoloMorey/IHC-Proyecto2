using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    private List<PokemonVariables> listPokemon; // RAM

    void Start()
    {
        listPokemon = new List<PokemonVariables>();
    }

    public void AddPokemon(PokemonVariables pokemon)
    {
        listPokemon.Add(pokemon);
    }

    public List<PokemonVariables> GetPokemon()
    {
        return listPokemon;
    }
}
