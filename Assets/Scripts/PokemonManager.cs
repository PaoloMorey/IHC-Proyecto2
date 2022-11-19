using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    private List<ModelPokemon> listMemoryPokemon; // disk in MongoDB
    private List<ModelPokemon> listRamPokemon; // RAM
    private DatabaseManager dbManager;
    private List<ModelPokemon> pokemonTeam;

    void Awake()
    {
        dbManager = FindObjectsOfType<DatabaseManager>()[0];
        listMemoryPokemon = dbManager.GetPokemonSortByDescendingCapturedAt();
        listRamPokemon = new List<ModelPokemon>();
        pokemonTeam = dbManager.GetPokemonInTeam();
    }

    public List<ModelPokemon> GetListPokemonTeam()
    {
        return pokemonTeam;
    }

    public void AddPokemon(ModelPokemon pokemon)
    {
        int contPokemonTeam = pokemonTeam.Count;
        if (contPokemonTeam == 6)
            pokemon.teamPos = -1;
        else {
            pokemon.teamPos = contPokemonTeam;
            pokemonTeam.Add(pokemon);
        }
        listRamPokemon.Add(pokemon);
    }

    public List<ModelPokemon> GetRamPokemon()
    {
        return listRamPokemon;
    }
}