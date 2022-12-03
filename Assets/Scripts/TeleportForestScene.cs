using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportForestScene : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            // SceneManager.LoadScene(1);
            collision.transform.position = GameManager.Instance.forestPosition;
            FindObjectsOfType<SpawnController>()[0].ForestSpawn();
        }
    }
}
