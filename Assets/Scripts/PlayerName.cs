using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    string[] names;
    GameObject[] games;
    GameObject[] newGames;
    [SerializeField]
    private DatabaseManager dbManager;

    void Start()
    {
        dbManager.InsertPlayer("playerName");
        // PlayerPrefs.DeleteKey("Game 1");
        // PlayerPrefs.SetString("Game 1", "Prueba");
        // Debug.Log(PlayerPrefs.GetString("Game 1"));
        games = GameObject.FindGameObjectsWithTag("Game");
        foreach (GameObject game in games)
            game.SetActive(false);
        newGames = GameObject.FindGameObjectsWithTag("New Game");
        foreach (GameObject newGame in newGames)
            newGame.SetActive(false);
        
        names = new string[]{"Game 1", "Game 2", "Game 3"};

        for (int i = 0; i < names.Length; i++)
        {
            string playerName = PlayerPrefs.GetString(names[i]);
            if (PlayerPrefs.GetString(names[i]) == "")
                newGames[i].SetActive(true);
            else {
                games[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerName;
                games[i].SetActive(true);
            }
        }
    }

    public void SelectName(string game) 
    {
        // string playerName = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text;
        dbManager.InsertPlayer("playerName");
        // if (dbManager.GetPlayer(playerName) == null)
        // {
        //     // PlayerPrefs.SetString(game, playerName);
        //     dbManager.InsertPlayer(playerName);
        // }
    }
}
