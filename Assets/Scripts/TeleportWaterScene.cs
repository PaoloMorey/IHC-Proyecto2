using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWaterScene : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "OVRPlayerController")
            SceneManager.LoadScene(2);
    }
}
