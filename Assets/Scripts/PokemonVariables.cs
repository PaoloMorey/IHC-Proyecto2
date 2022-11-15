using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonVariables : MonoBehaviour
{
    public string name { set; get; }
    public int level { private set; get; }
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
