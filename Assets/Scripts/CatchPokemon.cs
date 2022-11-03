using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPokemon : MonoBehaviour
{
    public GameObject catchFx; // particle
    private Animator anim;
    private GameObject pokemon;

    void Start()
    {
        anim = GetComponent<Animator>();
        pokemon = null;
    }

    float GetCatchFormula(int catchRate)
    {
        return catchRate*GameVariables.maxPercentCatchRate/GameVariables.maxCatchRate;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pokemon")) {
            pokemon = collision.gameObject;
            if (GetCatchFormula(pokemon.GetComponent<PokemonData>().GetCatchRate()) <= Random.Range(0.0f, 1.0f)) {
                Debug.Log("Catching "+name);
                anim.SetInteger("Capture", 1);
                // Instantiate(catchFx, transform.position, transform.rotation);
                // Destroy(catchFx, Random.Range(0.5f, 1.0f));
                // Destroy(gameObject);
                // Destroy(pokemon);
            }
            else {
                pokemon.SetActive(false);
                anim.SetInteger("Capture", -1);
            }
        }
    }

    public void FinishEvent()
    {
        if (anim.GetInteger("Capture") == -1)
        {
            Destroy(gameObject);
            if (pokemon != null)
                pokemon.SetActive(true);
        }
        else if (anim.GetInteger("Capture") == 1)
        {
            Instantiate(catchFx, transform.position, transform.rotation);
            Destroy(catchFx, Random.Range(0.5f, 1.0f));
            Destroy(gameObject);
            Destroy(pokemon);
        }
    }
}
