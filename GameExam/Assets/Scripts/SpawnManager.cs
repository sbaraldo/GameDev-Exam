using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleSpawnIndex;
    Transform spawnPoint;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // random spawnpoint for the obstacle
        obstacleSpawnIndex = Random.Range(0, 3);
        spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn obstacle to that position
        Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
    }
}
