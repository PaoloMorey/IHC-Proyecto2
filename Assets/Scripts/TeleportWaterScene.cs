using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWaterScene : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            // SceneManager.LoadScene(2);
            collision.transform.position = GameManager.Instance.waterPosition;
            FindObjectsOfType<SpawnController>()[0].WaterSpawn();
        }
    }
}
