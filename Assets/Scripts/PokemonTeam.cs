using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokemonTeam : MonoBehaviour
{
    [SerializeField]
    private PokemonManager pokemonManager;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private GameObject toggle;

    void Start()
    {
        List<ModelPokemon> aux = pokemonManager.GetListPokemonTeam();
        for (int i = 0; i < aux.Count; i++)
        {
            Transform currentToggle = Instantiate(toggle).transform;
            currentToggle.parent = content;
            RectTransform currentRectTransform = currentToggle.GetComponent<RectTransform>();
            currentRectTransform.localPosition = Vector3.zero;
            currentRectTransform.localScale = Vector3.one;
            currentToggle.GetChild(1).GetComponent<TextMeshProUGUI>().text = aux[i].name;
        }
    }

    public void AddNewPokemonTeam(ModelPokemon aux)
    {
        Transform currentToggle = Instantiate(toggle).transform;
        currentToggle.parent = content;
        RectTransform currentRectTransform = currentToggle.GetComponent<RectTransform>();
        currentRectTransform.localPosition = Vector3.zero;
        currentRectTransform.localScale = Vector3.one;
        currentToggle.GetChild(1).GetComponent<TextMeshProUGUI>().text = aux.name;
    }
}
