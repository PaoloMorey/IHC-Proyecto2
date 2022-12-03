using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPlayer : MonoBehaviour
{
    [SerializeField]
    float minHeight = -5.0f;

    void Update()
    {
        if (transform.position.y <= minHeight)
            transform.position = new Vector3(13.45f, 2.91f, 33.07f);
    }
}
