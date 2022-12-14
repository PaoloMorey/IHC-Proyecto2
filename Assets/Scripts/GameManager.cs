using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxCatchRate = 255;
    public float maxPercentCatchRate = 0.95f;
 
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