using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPokemon : MonoBehaviour
{
    float GetCatchFormula(int catchRate)
    {
        return catchRate*GameVariables.maxPercentCatchRate/GameVariables.maxCatchRate;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pokemon")) {
            GameObject pokemon = collision.gameObject;
            if (GetCatchFormula(pokemon.GetComponent<PokemonData>().GetCatchRate()) <= Random.Range(0.0f, 1.0f)) {
                Debug.Log("Catching "+name);
                Destroy(gameObject);
                Destroy(pokemon);
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}
