using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportForestScene : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "OVRPlayerController")
            SceneManager.LoadScene(1);
    }
}
