using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    Vector3 upperLeft = new Vector3(5, 5, 5);
    [SerializeField]
    Vector3 bottomRight = new Vector3(55, 5, 55);
    
    [SerializeField]
    int rows;
    [SerializeField]
    int cols;

    [SerializeField]
    GameObject[] pokemonArr;
    [SerializeField]
    GameObject pokeball;
    [SerializeField]
    float minOffset = 2.0f;
    [SerializeField]
    float maxOffset = 4.0f;

    void Start()
    {
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
                pokemonVariables.SetRandomLevel(5, 20);
                pokemonVariables.name = newSpawn.name.Replace("(Clone)", "");
                newSpawn.AddComponent<DestroyFall>();
                newPokeball.AddComponent<DestroyFall>();
            }
        }
    }
}
