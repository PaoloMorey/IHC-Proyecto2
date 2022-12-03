using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    Vector3 upperLeft = new Vector3(5, 2.5f, 5);
    [SerializeField]
    Vector3 bottomRight = new Vector3(55, 2.5f, 55);
    
    [SerializeField]
    int rows;
    [SerializeField]
    int cols;

    [SerializeField]
    GameObject[] pokemonArr;
    [SerializeField]
    GameObject pokeball;
    [SerializeField]
    float minOffset = 3.0f;
    [SerializeField]
    float maxOffset = 6.0f;
    [SerializeField]
    int minLevel = 5;
    [SerializeField]
    int maxLevel = 20;

    void Start()
    {
        // if (pokemonArr.Length != 0) 
        {
            ForestSpawn();
        }
        // else
        {
            WaterSpawn();
        }
    }

    public void ForestSpawn()
    {
        GameObject[] placedPokemonArr = GameObject.FindGameObjectsWithTag("Pokemon");
        foreach (GameObject pokemon in placedPokemonArr) {
            Destroy(pokemon);
        }
        GameObject[] placedPokeballArr = GameObject.FindGameObjectsWithTag("Pokeball");
        foreach (GameObject pokeball in placedPokeballArr) {
            Destroy(pokeball);
        }

        float incrX = (bottomRight.x - upperLeft.x) / (rows - 1.0f);
        float incrZ = (bottomRight.z - upperLeft.z) / (cols - 1.0f);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject pokemon = pokemonArr[Random.Range(0, pokemonArr.Length)];
                GameObject newSpawn = Instantiate(pokemon, new Vector3(upperLeft.x + incrX*i, 
                                        upperLeft.y, 
                                        upperLeft.z + incrZ*j), pokemon.transform.rotation);
                GameObject newPokeball = Instantiate(pokeball, new Vector3(upperLeft.x + incrX*i + Random.Range(minOffset, maxOffset), 
                                                upperLeft.y, 
                                                upperLeft.z + incrZ*j + Random.Range(minOffset, maxOffset)), pokeball.transform.rotation);
                newSpawn.transform.parent = transform;
                PokemonVariables pokemonVariables = newSpawn.GetComponent<PokemonVariables>();
                pokemonVariables.SetRandomLevel(minLevel, maxLevel);
                pokemonVariables.name = newSpawn.name.Replace("(Clone)", "");
                newSpawn.AddComponent<DestroyFall>();
                newPokeball.AddComponent<DestroyFall>();
            }
        }
    }

    public void WaterSpawn()
    {
        GameObject[] placedPokemonArr = GameObject.FindGameObjectsWithTag("WaterPokemon");
        // Debug.Log(placedPokemonArr);
        foreach (GameObject pokemon in placedPokemonArr) {
            GameObject newPokeball = Instantiate(pokeball, new Vector3(pokemon.transform.position.x + Random.Range(minOffset, maxOffset), 
                                                pokemon.transform.position.y, 
                                                pokemon.transform.position.z + Random.Range(minOffset, maxOffset)), pokeball.transform.rotation);
            PokemonVariables pokemonVariables = pokemon.GetComponent<PokemonVariables>();
            pokemonVariables.SetRandomLevel(minLevel, maxLevel);
            pokemonVariables.name = pokemon.name.Replace("(Clone)", "");
            pokemon.transform.parent = transform;
            pokemon.AddComponent<DestroyFall>();
            newPokeball.AddComponent<DestroyFall>();
        }
    }
}
