using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    Transform upperLeft;
    Transform bottomRight;
    GameObject spawn;
    
    [SerializeField]
    int rows;
    [SerializeField]
    int cols;  

    void Start()
    {
        spawn = GameObject.Find("UpperLeft");
        upperLeft = spawn.transform;
        bottomRight = GameObject.Find("BottomRight").transform;

        float incrX = (bottomRight.position.x - upperLeft.position.x) / (rows - 1.0f);
        float incrZ = (bottomRight.position.z - upperLeft.position.z) / (cols - 1.0f);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if ((i == 0 && j == 0) || (i == rows-1 && j == cols-1)) continue;
                GameObject newSpawn = Instantiate(spawn, new Vector3(upperLeft.position.x + incrX*i, 
                                        upperLeft.position.y, 
                                        upperLeft.position.z + incrZ*j), spawn.transform.rotation);
                newSpawn.transform.parent = transform;
            }
        }
    }
}
