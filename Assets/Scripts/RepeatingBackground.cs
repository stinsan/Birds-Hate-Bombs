using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RepeatingBackground : MonoBehaviour
{
    public float speed;
   
    public float endX;
    public float startX;

    private float timeElapsed = 0;

    public float speedMultiplierCoefficient;
    private float speedMultiplier;

    void Update() {

        if (SceneManager.GetActiveScene().name == "Main") { // Background speeds up if in main game
            timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
            speedMultiplier = 1 + (speedMultiplierCoefficient * timeElapsed);
        }
        else if (SceneManager.GetActiveScene().name == "Menu") { // Background speed is constant if in menu
            speedMultiplier = 1;
        }

        transform.Translate(Vector2.left * (speed * speedMultiplier) * Time.deltaTime);

        if (transform.position.x <= endX) { // Repeat background
            Vector3 pos = new Vector3(startX, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
