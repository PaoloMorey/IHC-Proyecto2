using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour
{
    string[] names;
    [SerializeField]
    GameObject[] games;
    [SerializeField]
    GameObject[] newGames;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < games.Length; i++)
        {
            string playerName = PlayerPrefs.GetString(games[i].name);

            if (playerName == "")
                newGames[i].SetActive(true);
            else {
                games[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerName;
                games[i].SetActive(true);
            }
        }
    }

    public void SelectName(string game) 
    {
        GameObject aux = GameObject.Find("New "+game);
        string playerName = aux.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text;
        if (playerName == null || playerName == "" || playerName.Length != 0) {
            PlayerPrefs.SetString(game, aux.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text);
            aux.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }

    public void LoadGame(string game)
    {
        GameManager.Instance.playerName = PlayerPrefs.GetString(game);
        SceneManager.LoadScene(1);
    }
}
