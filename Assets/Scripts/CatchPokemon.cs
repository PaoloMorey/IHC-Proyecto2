using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPokemon : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pokeball")) {
            Debug.Log("Catching "+name);
            Destroy(gameObject);
        }
    }
}
