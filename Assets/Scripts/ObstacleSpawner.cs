using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Update() {
        
        if (timeBetweenSpawn <= 0) {

            int randomNum = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[randomNum], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

            if (startTimeBetweenSpawn > minTime) {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else {

            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
