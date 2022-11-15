using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFall : MonoBehaviour
{
    [SerializeField]
    float minHeight = -5.0f;

    void Update()
    {
        if (transform.position.y <= minHeight)
            Destroy(gameObject);
    }
}
