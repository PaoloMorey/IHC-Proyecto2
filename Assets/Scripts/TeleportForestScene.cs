using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportForestScene : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // void OnCollisionEnter(Collision collision)
    void Update()
    {
        // Debug.Log(Vector3.Distance(player.position, transform.position));
        // if (collision.transform.CompareTag("Player")) {
        if (Vector3.Distance(player.position, transform.position) <= GameManager.Instance.teleportDistance) {
            player.position = GameManager.Instance.forestPosition;
            FindObjectsOfType<SpawnController>()[0].ForestSpawn();
        }
    }
}
