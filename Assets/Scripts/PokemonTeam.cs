using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokemonTeam : MonoBehaviour
{
    private PokemonManager pokemonManager;
    [SerializeField]
    private GameObject[] slots;

    void Start()
    {
        pokemonManager = FindObjectsOfType<PokemonManager>()[0];
        List<ModelPokemon> aux = pokemonManager.GetListPokemonTeam();
        for (int i = 0; i < aux.Count; i++)
        {
            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = aux[i].name;
            slots[i].SetActive(true);
        }
    }

    public void AddNewPokemonTeam(ModelPokemon aux)
    {
        slots[aux.teamPos].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = aux.name;
        slots[aux.teamPos].SetActive(true);
    }
}
