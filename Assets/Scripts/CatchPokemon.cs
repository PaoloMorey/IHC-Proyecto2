using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPokemon : MonoBehaviour
{
    [SerializeField]
    private GameObject catchFx; // particle
    private Rigidbody rb;
    private Animator anim;
    private GameObject pokemon;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        pokemon = null;
    }

    float GetCatchFormula(int catchRate)
    {
        return catchRate*GameManager.Instance.maxPercentCatchRate/GameManager.Instance.maxCatchRate;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pokemon")) {
            pokemon = collision.gameObject;
            FindObjectsOfType<AudioManager>()[0].PlayAudioSource(pokemon.name.Replace("(Clone)", ""));
            pokemon.SetActive(false);
            PokemonVariables pokemonVariables = pokemon.GetComponent<PokemonVariables>();
            if (GetCatchFormula(pokemonVariables.GetCatchRate()) <= Random.Range(0.0f, 1.0f)) {
                Debug.Log("Catching "+pokemon.name);
                FindObjectsOfType<PokemonManager>()[0].AddPokemon(pokemonVariables);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                anim.SetInteger("Capture", 1);
            }
            else {
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
            rb.constraints = RigidbodyConstraints.None;
        }
        else if (anim.GetInteger("Capture") == 1)
        {
            if (catchFx != null) 
            {
                GameObject obj = Instantiate(catchFx, transform.position, transform.rotation);
                Destroy(obj, Random.Range(0.5f, 1.0f));
            }
            Destroy(gameObject);
            Destroy(pokemon);
        }
    }
}
