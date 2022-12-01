using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSceneLoader : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "OVRPlayerController") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
