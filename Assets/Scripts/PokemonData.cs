using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    [SerializeField]    
    int level;
    [SerializeField]
    int catchRate;

    public void SetRandomLevel(int min, int max)
    {
        level = Random.Range(min, max);
    }

    public int GetCatchRate()
    {
        return catchRate;
    }
}
