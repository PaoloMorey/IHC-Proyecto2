using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowText : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        transform.LookAt(target.position);
        transform.Rotate(0, 180, 0);
    }
}
