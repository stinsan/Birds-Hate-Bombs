using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject upEffect;
    public GameObject downEffect;
    public GameObject gameOverMenu;
    public GameObject gameOverSound;
    public GameObject pauseMenu;

    public Animator playerAnim;

    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI scoreDisplay;

    private Vector2 targetPos;
    public int yIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health;

    public float timeElapsed = 0;

    void Start() {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update() {

        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        // If health is 0 or less, pull up the game over screen
        if (health <= 0) {
            gameOverMenu.SetActive(true);
            Instantiate(gameOverSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // Set health UI text to current player health value
        healthDisplay.text = "health: " + health.ToString();

        // Set score to time elapsed * 100
        scoreDisplay.text = "score: " + ((int)(timeElapsed * 100)).ToString();

        // Up arrow or W movement
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) 
            && transform.position.y + yIncrement <= maxHeight) {

            Instantiate(upEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
        }
        // Down arrow or S movement
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) 
            && transform.position.y - yIncrement >= minHeight) {

            Instantiate(downEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
        }

        // Move towards targetPos
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Update time elapsed as long as player is alive
        if (health > 0) {
            timeElapsed += Time.deltaTime;
        }
    }
}
