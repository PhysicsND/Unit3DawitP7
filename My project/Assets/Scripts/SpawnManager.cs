using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnRandomObstacle), startDelay, repeatRate);
    }

    void SpawnRandomObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            Instantiate(
                obstaclePrefabs[obstacleIndex],
                spawnPos,
                obstaclePrefabs[obstacleIndex].transform.rotation
            );
        }
    }
}