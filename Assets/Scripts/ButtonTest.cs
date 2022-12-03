using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    PokemonManager pokemonManager;

    void Start()
    {
        pokemonManager = FindObjectsOfType<PokemonManager>()[0];
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            mainMenu.SetActive(!mainMenu.active);
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            pokemonManager.SaveTeam();
            PlayerPrefs.SetString("current", "");
            SceneManager.LoadScene(0);
        }
    }
}