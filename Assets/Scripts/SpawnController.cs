using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    Vector3 upperLeft = new Vector3(5, 5, 5);
    Vector3 bottomRight = new Vector3(55, 5, 55);
    GameObject spawn;
    
    [SerializeField]
    int rows;
    [SerializeField]
    int cols;

    [SerializeField]
    GameObject[] pokemonArr;

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
                newSpawn.transform.parent = transform;
            }
        }
    }
}
