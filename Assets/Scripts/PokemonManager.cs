using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    private List<ModelPokemon> listMemoryPokemon; // disk in MongoDB
    private List<ModelPokemon> listRamPokemon; // RAM
    private DatabaseManager dbManager;

    void Start()
    {
        dbManager = FindObjectsOfType<DatabaseManager>()[0];
        listMemoryPokemon = dbManager.GetPokemonSortByDescendingCapturedAt();
        listRamPokemon = new List<ModelPokemon>();
    }

    public void AddPokemon(ModelPokemon pokemon)
    {
        listRamPokemon.Add(pokemon);
    }

    public List<ModelPokemon> GetRamPokemon()
    {
        return listRamPokemon;
    }
}