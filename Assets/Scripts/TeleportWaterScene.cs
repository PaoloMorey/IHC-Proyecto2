using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWaterScene : MonoBehaviour
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
        if (Vector3.Distance(player.position, transform.position) <= 3.5f) {
            player.position = new Vector3(-110, 5.5f, 10);
            FindObjectsOfType<SpawnController>()[0].WaterSpawn();
        }
    }
}
