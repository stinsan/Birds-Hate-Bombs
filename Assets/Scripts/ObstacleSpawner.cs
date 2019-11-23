using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;
    public float timeBetweenSpawnLowerBound;
    public float timeBetweenSpawnUpperBound;
    
    private void Update() {
        
        if (timeBetweenSpawn <= 0) {

            int randomNum = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[randomNum], transform.position, Quaternion.identity);
            timeBetweenSpawn = Random.Range(timeBetweenSpawnLowerBound, timeBetweenSpawnUpperBound);
        }
        else {

            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
