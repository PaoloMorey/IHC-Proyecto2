using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSceneLoader : MonoBehaviour
{
    [SerializeField]
    int sceneId;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "OVRPlayerController") {
            SceneManager.LoadScene(sceneId);
        }
    }
}
