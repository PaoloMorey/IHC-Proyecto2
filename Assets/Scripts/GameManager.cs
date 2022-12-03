using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxCatchRate = 255;
    public float maxPercentCatchRate = 0.95f;
    public string playerName = "";
    public Vector3 forestPosition = new Vector3(35, 2.91f, 22);
    public Vector3 waterPosition = new Vector3(-110, 5.5f, 10);
 
    private static GameManager _instance;
 
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
 
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    } 
}