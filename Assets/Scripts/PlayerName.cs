using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Firestore;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase;
using System;

public class PlayerName : MonoBehaviour
{
    string[] names;
    [SerializeField]
    GameObject[] games;
    [SerializeField]
    GameObject[] newGames;

    void Start()
    {   
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            // Debug.Log("trika");
        });
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("users").Document("Bikaclif");
        Dictionary<string, object> user = new Dictionary<string, object>
        {
            { "name", "Bikaclif" }
        };
        docRef.SetAsync(user).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the Bikaclif document in the users collection.");
        });

        // // Debug.Log(db);
        // CollectionReference usersRef = db.Collection("users");
        // // Debug.Log(usersRef);
        // usersRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        // {
        //     QuerySnapshot snapshot = task.Result;
        // //     Debug.Log("bika");
        // //     // foreach (DocumentSnapshot document in snapshot.Documents)
        // //     // {
        // //     //     Debug.Log(String.Format("User: {0}", document.Id));
        // //     //     Dictionary<string, object> documentDictionary = document.ToDictionary();
        // //     //     Debug.Log(String.Format("First: {0}", documentDictionary["name"]));
        // //     // }

        // //     // Debug.Log("Read all data from the users collection.");
        // });

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
        PlayerPrefs.SetString(game, aux.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text);
        aux.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void LoadGame(string game)
    {
        var a = PlayerPrefs.GetString(game);
        SceneManager.LoadScene(1);
    }
}
